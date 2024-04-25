/////////////////////////////////////////////////////////////////////
//　File name  : FlashChar.cs                                      //
//　Objective  : 文字の点滅                                        //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;

public class FlashChar : MonoBehaviour {
    //サイン値によって求まるα値
    float alpha_sin = 0.0f;
    //文字の色
    Color color = new Color(255,255,255);

	// Use this for initialization
	void Start () {            
    }

    // Update is called once per frame
    void Update()
    {
        //色情報の更新
        gameObject.GetComponent<SpriteRenderer>().color = GetAlphaColor(color);
    }

    //α値の取得
    Color GetAlphaColor(Color color)
    {
        //α値を求める
        alpha_sin = Mathf.Sin(Time.time * 3) / 2 + 0.5f;
        //α値を適用
        color.a = alpha_sin;
        //色情報を返す
        return color;
    }
}
