/////////////////////////////////////////////////////////////////////
//　File name  : BackMusicController.cs                            //
//　Objective  : BGM等の音の管理                                   //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;

public class BackMusicController : MonoBehaviour {
    //BGM
    public AudioClip back;
    //オーディオ
    new AudioSource audio;

    // Use this for initialization
    void Start()
    {
        //オーディオの初期化
        audio = GetComponent<AudioSource>();
        //オーディオの設定
        audio.clip = back;
        //ループ可
        audio.loop = true;
        //BGMを継続させる
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update () {
        //フラグが立っている間音楽を流す
        if (data.IsMusicFlag())
        {
            Destroy(gameObject);
        }
    }
}
