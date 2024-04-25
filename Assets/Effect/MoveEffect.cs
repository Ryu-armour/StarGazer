/////////////////////////////////////////////////////////////////////
//　File name  : MoveEffect.cs                                     //
//　Objective  : プレイヤーが移動した際のエフェクト                //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using UnityEngine;

public class MoveEffect : MonoBehaviour {
    //プレイヤー
    public GameObject player;
    //エフェクト
    ParticleSystem particle;

    // Use this for initialization
    void Start () {
        //パーティクルのセット
        particle = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        //移動したプレイヤーを追従
        particle.transform.position = player.transform.position;
	}
}
