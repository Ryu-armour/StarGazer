/////////////////////////////////////////////////////////////////////
//　File name  : ResultController.cs                               //
//　Objective  : リザルトシーン                                    //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;

public class ResultController : MonoBehaviour {
    //シーン遷移クラス
    GameObject sceneTransition;

	// Use this for initialization
	void Start () {
        //オブジェクトのセット
        sceneTransition = GameObject.Find("SceneManager");
	}
	
	// Update is called once per frame
	void Update () {
        //スペースキーが入力された
		if(Input.GetKeyDown(KeyCode.Space))
        {
            //シーン遷移
            sceneTransition.GetComponent<SceneTransition>().sceneName = data.scene_name;
        }
	}
}
