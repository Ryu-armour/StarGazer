/////////////////////////////////////////////////////////////////////
//　File name  : data.cs                                           //
//　Objective  : 1次的に必要になるデータの置き場                   //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;

public class data : MonoBehaviour {
    //音楽をかけるかどうか
    public static bool music_frag = false;
    //今のシーン名
    public static string scene_name = "StageSelect";

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //フラグの状態を返す
    public static bool IsMusicFlag()
    {
        return music_frag;
    }
}
