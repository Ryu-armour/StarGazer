/////////////////////////////////////////////////////////////////////
//　File name  : StageSelect.cs                                    //
//　Objective  : ステージセレクト                                  //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    //ステージ選択時のオーディオ
    public AudioClip choiceAudio;
    //オーディオ情報
    new AudioSource audio;
    //シーン遷移クラス
    GameObject sceneTransition;
    //プレイヤー
    GameObject player;

    // Use this for initialization
    void Start()
    {
        //シーン名をセット
        if (SceneManager.GetActiveScene().name != "SceneTitle")
        {
            data.scene_name = SceneManager.GetActiveScene().name;
        }

        //オブジェクトのセット
        sceneTransition = GameObject.Find("SceneManager");
        player = GameObject.Find("Player");

        //オーディオをセット
        audio = GetComponent<AudioSource>();
        audio.clip = choiceAudio;
        audio.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //シーン名をセット
    void SetSceneName()
    {
        //シーン遷移するスクリプトに飛ぶシーンの名前を格納
        if (transform.name == "1")
        {
            sceneTransition.GetComponent<SceneTransition>().sceneName = "Stage1";
        }
        if (transform.name == "2")
        {
            sceneTransition.GetComponent<SceneTransition>().sceneName = "Stage2";
        }
        if (transform.name == "3")
        {
            sceneTransition.GetComponent<SceneTransition>().sceneName = "Stage3";
        }
        if (transform.name == "4")
        {
            sceneTransition.GetComponent<SceneTransition>().sceneName = "Stage4";
        }
        if (transform.name == "5")
        {
            sceneTransition.GetComponent<SceneTransition>().sceneName = "Stage5";
        }
        if (transform.name == "6")
        {
            sceneTransition.GetComponent<SceneTransition>().sceneName = "Stage6";
        }
        if (transform.name == "7")
        {
            sceneTransition.GetComponent<SceneTransition>().sceneName = "Stage7";
        }
        if (transform.name == "8")
        {
            sceneTransition.GetComponent<SceneTransition>().sceneName = "Stage8";
        }
        if (transform.name == "9")
        {
            sceneTransition.GetComponent<SceneTransition>().sceneName = "Stage9";
        }

        //1つ後のセレクト画面に進む
        if (transform.name == "Next")
        {
            if (SceneManager.GetActiveScene().name == "StageSelect" || SceneManager.GetActiveScene().name == "SceneTitle")
            {
                sceneTransition.GetComponent<SceneTransition>().sceneName = "StageSelect2";
            }
            else if (SceneManager.GetActiveScene().name == "StageSelect2")
            {
                sceneTransition.GetComponent<SceneTransition>().sceneName = "StageSelect3";
            }
        }

        //1つ前のセレクト画面に戻る
        if (transform.name == "Back")
        {
            if (SceneManager.GetActiveScene().name == "StageSelect2")
            {
                sceneTransition.GetComponent<SceneTransition>().sceneName = "StageSelect";
            }
            else if (SceneManager.GetActiveScene().name == "StageSelect3")
            {
                sceneTransition.GetComponent<SceneTransition>().sceneName = "StageSelect2";
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーを衝突
        if (collision.tag == "Player")
        {
            //ジャンプ音再生
            AudioSource.PlayClipAtPoint(choiceAudio, transform.position);

            //次のステージをセット
            player.GetComponent<PlayerController>().isHitStage = true;
            SetSceneName();
        }
    }
}
