/////////////////////////////////////////////////////////////////////
//　File name  : GameController.cs                                 //
//　Objective  : ゲームのクリア状況の管理                          //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;

public class GameController : MonoBehaviour {
    //ゲーム状況 true:クリア, false:まだクリアしていない
    public bool isFinish = false;
    //敵が生きているか true:生きている, false:死んでいる
    public bool isEnemyArrive = false;

    //プレイヤー
    GameObject player;
    //マップ内の星
    GameObject[] stars;
    //シーン遷移クラス
    GameObject sceneTransition;

	// Use this for initialization
	void Start () {
        //ゲームオブジェクトのセット
        player = GameObject.Find("Player");
        sceneTransition = GameObject.Find("SceneManager");
	}
	
	// Update is called once per frame
	void Update () {
        //マップ内の星の残り数を数える
        Check("Star");

        //星がすべて無くなった
        if(stars.Length == 0)
        {
            //終了のフラグを立てる
            isFinish = true;
            //敵が死んでいたら
            if(!isEnemyArrive)
            {
                //プレイヤーにクリアしたと伝える
                player.GetComponent<PlayerController>().isClear = true;
                //シーン遷移
                sceneTransition.GetComponent<SceneTransition>().sceneName = "SceneClear";
            }
        }
    }

    //星がマップ内に残ってるかチェック
    void Check(string tagname)
    {
        stars = GameObject.FindGameObjectsWithTag(tagname);
    }
}
