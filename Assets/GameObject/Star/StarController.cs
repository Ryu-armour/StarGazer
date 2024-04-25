/////////////////////////////////////////////////////////////////////
//　File name  : StarController.cs                                 //
//　Objective  : 星の管理                                          //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;

public class StarController : MonoBehaviour {
    //取得音
    public AudioClip disappearance;
    //オーディオ情報
    new AudioSource audio;

    // Use this for initialization
    void Start () {
        //オーディオの初期化
        audio = GetComponent<AudioSource>();
        audio.clip = disappearance;
        audio.loop = false;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーと衝突
        if(collision.tag == "Player")
        {
            //音を鳴らす
            AudioSource.PlayClipAtPoint(disappearance, transform.position);
            //自壊
            Destroy(gameObject);
        }
    }
}
