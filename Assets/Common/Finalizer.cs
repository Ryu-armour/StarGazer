/////////////////////////////////////////////////////////////////////
//　File name  : Finalizer.cs                                      //
//　Objective  : ゲーム終了                                        //
//　maker      : Oyama Ryuhei                                      //
/////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finalizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Escキーでゲーム終了
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
