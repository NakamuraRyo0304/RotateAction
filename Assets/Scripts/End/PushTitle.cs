using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushTitle : MonoBehaviour
{
    [SerializeField]
    [Header("�X�y�[�X�t�H���g")]
    GameObject space;
    
    [SerializeField]
    [Header("�^�C�g����")]
    GameObject title;


    void Start()
    {
        title.SetActive(false);
        space.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(EndingManager.canTitleFlag)
        {
            title.SetActive(true);
            space.SetActive(true);
        }
    }
}
