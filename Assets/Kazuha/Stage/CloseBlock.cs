using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBlock : MonoBehaviour
{
    //��`
    private Animator anime;

    //������
    private void Start()
    {
        anime = gameObject.GetComponent<Animator>();
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            Debug.Log("�ʂ������O�O");
            anime.SetBool("Close", true);
            
        }
    }
}
