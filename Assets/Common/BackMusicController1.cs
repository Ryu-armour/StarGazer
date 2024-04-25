/////////////////////////////////////////////////////////////////////
//　File name  : BackMusicController1.cs                           //
//　Objective  : BGM等の音の管理                                   //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMusicController1 : MonoBehaviour {
    //音楽を
    private bool DontDestroyEnabled = true;

    // Use this for initialization
    void Start()
    {
        //すでに音楽がかかっていたらこのオブジェクトを消す
        if (data.music_frag)
        {
            Destroy(gameObject);
        }
        else
        {
            data.music_frag = true;
        }
        //BGMを継続
        if (DontDestroyEnabled)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        //タイトルシーンとステージセレクトシーンでは曲を続ける
		if(SceneManager.GetActiveScene().name == "SceneTitle" || SceneManager.GetActiveScene().name == "StageSelect" 
            || SceneManager.GetActiveScene().name == "StageSelect2" || SceneManager.GetActiveScene().name == "StageSelect3")
        {}
        //それ以外のシーンでは今流れている曲を消す
        else
        {
            //オブジェクトを消す
            Destroy(gameObject);
            //音が流れてないからフラグをoffにする
            data.music_frag = false;
        }
    }
}
