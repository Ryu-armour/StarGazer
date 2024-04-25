/////////////////////////////////////////////////////////////////////
//　File name  : StarButton.cs                                     //
//　Objective  : 星の管理                                          //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーと衝突
        if(collision.tag == "Player")
        {
            //セレクト画面に遷移
            SceneManager.LoadScene("StageSelect");
        }
    }
}
