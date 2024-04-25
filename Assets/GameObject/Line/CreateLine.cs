/////////////////////////////////////////////////////////////////////
//　File name  : BackMusicController1.cs                           //
//　Objective  : BGM等の音の管理                                   //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;

public class CreateLine : MonoBehaviour {
    //始点
    public GameObject point1;
    //終点
    public GameObject point2;

    //線の太さ
    const float WIDTH = 0.2f; 

	// Use this for initialization
	void Start () {
        //線の設定
        LineRenderer renderer = gameObject.GetComponent<LineRenderer>();
        //始点と終点の太さを設定
        renderer.startWidth = WIDTH;
        renderer.endWidth = WIDTH;
        //線の点の数を設定
        renderer.positionCount = 2;
        //始点と終点の位置を設定
        renderer.SetPosition(0, point1.transform.position);
        renderer.SetPosition(1, point2.transform.position);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
