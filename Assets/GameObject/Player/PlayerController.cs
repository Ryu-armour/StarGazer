/////////////////////////////////////////////////////////////////////
//　File name  : PlayerController.cs                               //
//　Objective  : プレイヤーの管理                                  //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //ジャンプ時のエフェクト
    public GameObject jumpParticle;
    //死亡時のエフェクト
    public GameObject deadParticle;
    //Roadの頂点用の配列
    public Vector3[] vertices;
    //Roadの配列の要素数
    public int destination;
    //クリア
    public bool isClear;
    //ステージセレクト画面でステージに当たったか
    public bool isHitStage;
    //ジャンプ用のオーディオ
    public AudioClip jumpAudio;
    //オーディオ情報
    new AudioSource audio;

    //プレイヤーの移動の速さ
    const float MOVESPEED = 8f;
    //プレイヤーのジャンプの速さ
    const float JUMPSPEED = 50.0f;

    //プレイヤーの向き
    int playerDirection;
    //ジャンプのクールタイム
    int cooldownTime;
    //プレイヤーのスケール値
    float playerScale;
    //生存
    bool isAlive;
    //時計回り.true 反時計回り.false
    bool CW;
    //ジャンプしているかどうか
    bool IsJump;
    //rayに当たったか当たってないか(ジャンプの目的地が変わる)
    bool isRayHit;
    //シーン遷移用オブジェクト
    GameObject sceneTransition;
    //ゲームコントローラー
    GameObject gameController;
    //移動ベクトルの単位ベクトル
    Vector3 unitVector;
    //ジャンプのベクトル
    Vector3 jumpVel;
    //ジャンプ先のポジション
    Vector3 jumpDestination;

    // Use this for initialization
    void Start()
    {
        //変数のリセット
        destination = 0;
        cooldownTime = 0;
        //変数に値をセット
        playerScale = 1.0f;
        playerDirection = 1;
        //フラグのリセット
        isAlive = true;
        isClear = false;
        isHitStage = false;
        IsJump = false;
        CW = true;
        //オーディオをセット
        audio = GetComponent<AudioSource>();
        //オブジェクトをセット
        sceneTransition = GameObject.Find("SceneManager");
        gameController = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHitStage && isAlive)
        {
            //単位ベクトルの取得
            unitVector = (Vector3.MoveTowards(this.transform.position, vertices[destination], MOVESPEED * Time.deltaTime) - transform.position).normalized;
            //プレイヤーの基本的な行動
            PlayerAction();
            //スペースキーが押されたらジャンプ可能か結果をjumpに代入する
            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpResult();
            }
            //次の移動先の決定
            DecideDestination();
        }
        //プレイヤー死亡
        if (!isAlive)
        {
            PlayDisappear();
        }
    }

    //プレイヤーの行動
    void PlayerAction()
    {
        //ジャンプしてない間は目的地まで移動
        if (!IsJump)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, vertices[destination], MOVESPEED * Time.deltaTime);
            cooldownTime--;
        }
        else
        {
            //クールタイムが0以下ならジャンプ
            if (cooldownTime <= 0)
            {
                PlayJump();
            }
        }
    }

    //Rayを飛ばした結果
    void JumpResult()
    {
        //ジャンプのクールタイム判断
        if (cooldownTime <= 0)
        {
            //ジャンプ中でない
            if (!IsJump)
            {
                //ジャンプ音再生
                audio.PlayOneShot(jumpAudio);
                //ジャンプ状態にする
                IsJump = true;

                //RayがRoadタグにヒットしたか
                if (SendRay())
                {
                    isRayHit = true;
                }
                else
                {
                    isRayHit = false;
                }
            }
        }
    }

    //次の移動先の決定(通常時)
    void DecideDestination()
    {
        //接触しているRoadの配列を要素数を代入
        int length = vertices.Length;
        if (this.transform.position == vertices[destination])
        {
            //バグの防止
            IsJump = false;
            //時計回りの処理
            if (CW)
            {
                //destinationがRoadの配列の最後の要素数なら反時計回りにする
                if (destination == length - 1)
                {
                    CW = false;
                }
                else
                {
                    destination++;
                }
            }
            //反時計回りの処理
            else
            {
                //destinationがRoadの配列の最初の要素数なら時計回りにする
                if (destination == 0)
                {
                    CW = true;
                }
                else
                {
                    destination--;
                }
            }
        }
    }

    //ジャンプをする
    void PlayJump()
    {
        //ジャンプの実行
        if (isRayHit)
        {
            //Rayが当たったところまで移動
            transform.position = Vector3.MoveTowards(transform.position, jumpDestination, JUMPSPEED * Time.deltaTime);
            //クールタイムの設定,IsJumpフラグを戻す
            if (transform.position == jumpDestination)
            {
                Instantiate(jumpParticle, transform.position, transform.rotation);
                cooldownTime = 6;
                IsJump = false;
            }
        }
        else
        {
            //jumpVelの方向へ移動する
            transform.Translate(jumpVel);
        }
    }

    //Rayを飛ばす
    bool SendRay()
    {
        //画面外の壁と当たったベクトルの長さ
        float[] vectorMag = new float[2];
        //ジャンプ先の方向
        int jumpDirection = -1;
        //Rayの飛ばす方向
        Vector3 rayVel;
        //Rayの飛ばす距離
        float distance = 105.0f;
        //直角の両方向にオブジェクトがあるか判定用のループ
        for (int i = 0; i < 2; i++)
        {
            //Rayの方向の計算
            rayVel = new Vector3(-unitVector.y * jumpDirection * playerDirection, unitVector.x * jumpDirection * playerDirection, 0).normalized;
            Ray ray;
            Vector3 rayPos;
            //Rayのポジションをプレイヤーに当たらないよう設定
            rayPos = transform.position + rayVel;
            ray = new Ray(rayPos, rayVel);
            //レイヤーマスクの宣言
            int layerMask = 1 << 8 | 1 << 9;
            //Rayの当たり判定用
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, distance, layerMask);
            //Rayの可視化
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, 1.0f);
            //Rayがオブジェクトと衝突した処理
            if (hit.collider)
            {
                if (hit.collider.tag == "Road" || hit.collider.tag == "Damage")
                {
                    //Rayが当たったポジションをジャンプ先に設定
                    jumpDestination = hit.point;
                    return true;
                }
                if (hit.collider.tag == "Out")
                {
                    //画面外と当たったらその長さを計算
                    Vector3 hitMag = new Vector3(hit.point.x, hit.point.y, 0) - transform.position;
                    vectorMag[i] = Mathf.Abs(hitMag.magnitude);
                }
            }
            //両方向のどちらにもRoadがない場合反対側の画面外に飛ばす
            if (i == 1)
            {
                if (vectorMag[0] <= vectorMag[1])
                {
                    jumpVel = rayVel * jumpDirection;
                }
                else
                {
                    jumpVel = rayVel * -jumpDirection;
                }
            }
            //Rayを飛ばす方向を逆にする
            jumpDirection *= -1;
        }
        return false;
    }

    //プレイヤーを徐々に消す(死亡時)
    void PlayDisappear()
    {

        //プレイヤーに代入するスケールの値
        if (playerScale > 0)
        {
            playerScale -= 0.01f;
            transform.localScale = new Vector3(playerScale, playerScale, playerScale);
        }
        else
        {
            if (gameObject.activeSelf)
            {
                //オブジェクトを非アクティブに
                this.gameObject.SetActive(false);
                //プレイヤーのスケールを戻す
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                //エフェクトの再生
                Instantiate(deadParticle, transform.position, transform.rotation);
            }
            if (gameObject.activeSelf == false)
            {
                //シーン遷移先を格納
                sceneTransition.GetComponent<SceneTransition>().sceneName = "SceneFailure";
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //クリアしていない間だけ判定
        if (!isClear)
        {
            //Damageタグのオブジェクトに当たった
            if (collision.tag == "Damage" || collision.tag == "Out")
            {
                //死亡フラグを立てる
                isAlive = false;
            }
            //エネミータグのオブジェクトに当たった
            if (collision.tag == "Enemy")
            {
                //敵が生きていたら死亡フラグを立てる
                if (gameController.GetComponent<GameController>().isEnemyArrive)
                {
                    isAlive = false;
                }
            }
        }
    }
}