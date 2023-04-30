using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorTextureChange : MonoBehaviour
{
    // �������
    public Sprite lockImage;
    // �������
    public Sprite unlockImage;

    // �摜�`��p�̃R���|�[�l���g
    SpriteRenderer sr;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = lockImage;
    }

    void Update()
    {
        if(PlayerController.keyFlag)
        {
            sr.sprite = unlockImage;
        }
    }
}