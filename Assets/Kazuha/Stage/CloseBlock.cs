using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBlock : MonoBehaviour
{
    //定義
    private Animator anime;

    //初期化
    private void Start()
    {
        anime = gameObject.GetComponent<Animator>();
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            Debug.Log("通ったお＾＾");
            anime.SetBool("Close", true);
            
        }
    }
}
