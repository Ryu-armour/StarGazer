/////////////////////////////////////////////////////////////////////
//　File name  : FadeController.cs                                 //
//　Objective  : フェードイン、フェードアウトの実行                //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;
public class FadeController : MonoBehaviour {
    //trueでフェードアウト
    public bool isFadeOut;
    //trueでフェードイン
    public bool isFadeIn;
    //フェードイン・アウトが終了した
    public bool isFin;

    //Panelを入れる
    Image fadeImage;
    //フェードの切り替わる速さ
    float fadeSpeed = 0.01f;
    //PanelのColorに入れる
    float red, green, blue, alpha;

    // Use this for initialization
	void Start () {
        //フラグを戻す
        isFadeOut = false;
        isFadeIn = false;
        isFin = false;
        //Panelの色情報
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alpha = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        //フラグが立ったらフェードイン実行
        if (isFadeIn)
        {
            StartFadeIn();
        }
        //フラグが立ったらフェードアウト実行
        if (isFadeOut)
        {
            StartFadeOut();
        }
    }

    //フェードアウトの開始
    public void StartFadeOut()
    {//panelを表示
        fadeImage.enabled = true;
        //どんどん暗くする
        alpha += fadeSpeed;
        //alpha値をセット
        SetAlpha();
        //alphaが1以上になったらフラグをfalse
        if (alpha >= 1)
        {
            //終わったことを知らせる
            isFin = true;
            //フラグを戻す
            isFadeOut = false;
        }
    }

    //フェードインの開始
    public void StartFadeIn()
    {
        //どんどん明るくする
        alpha -= fadeSpeed;
        //alpha値をセット
        SetAlpha();
        //alpha値が0以下になったらフラグをfalse
        if (alpha <= 0)
        {
            //Panelを非表示
            fadeImage.enabled = false;
            //終わったことを知らせる
            isFin = true;
            //フラグを戻す
            isFadeIn = false;
        }
    }

    //α値をセット
    void SetAlpha()
    {
        //値の代入
        fadeImage.color = new Color(red, green, blue, alpha);
    }
}
