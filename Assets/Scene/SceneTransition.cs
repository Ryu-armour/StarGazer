/////////////////////////////////////////////////////////////////////
//　File name  : SceneTransition.cs                                //
//　Objective  : シーン遷移                                        //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {
    //次のシーン名
    public string sceneName;
    //フェードイン・アウトのクラス
    GameObject fadeController;

    // Use this for initialization
    void Start () {
        //初期化
        sceneName = null;
        fadeController = GameObject.Find("Panel");
    }

    // Update is called once per frame
    void Update () {
        //次のシーン情報が入ったらフェードアウト
        if (sceneName != null)
        {
            if (fadeController.GetComponent<FadeController>().isFadeOut == false)
            {
                //フェードアウト開始
                fadeController.GetComponent<FadeController>().isFadeOut = true;
                //フェードアウトがおわったら
                if (fadeController.GetComponent<FadeController>().isFin)
                {
                    //シーン遷移
                    SceneManager.LoadScene(sceneName);
                }
            }
        }
    }

}
