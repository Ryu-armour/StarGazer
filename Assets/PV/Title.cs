/////////////////////////////////////////////////////////////////////
//　File name  : Title.cs                                          //
//　Objective  : タイトルシーン                                    //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Title : MonoBehaviour {
    //α値を
    SpriteRenderer color;

	// Use this for initialization
	void Start () {
        //設定
        color = GetComponent<SpriteRenderer>();
        //α値を正常に戻す
        color.color = new Color(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update () {
	}
}
