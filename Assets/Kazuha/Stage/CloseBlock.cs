using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBlock : MonoBehaviour
{
    //íËã`
    private Animator anime;

    //èâä˙âª
    private void Start()
    {
        anime = gameObject.GetComponent<Animator>();
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            Debug.Log("í Ç¡ÇΩÇ®ÅOÅO");
            anime.SetBool("Close", true);
            
        }
    }
}
