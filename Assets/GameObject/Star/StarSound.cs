/////////////////////////////////////////////////////////////////////
//　File name  : StarSound.cs                                      //
//　Objective  : 星の音のフラグ管理                                //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;

public class StarSound : MonoBehaviour {
    //音を鳴らすフラグ
    public static bool music_flag = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //
    public static bool proto()
    {
        return music_flag;
    }
}
