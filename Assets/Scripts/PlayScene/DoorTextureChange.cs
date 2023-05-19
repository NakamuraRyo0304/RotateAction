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
        ResetTexture();
    }

    void Update()
    {
        if(PlayerController.keyFlag)
        {
            sr.sprite = unlockImage;
        }
    }

    public void ResetTexture()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = lockImage;
        PlayerController.keyFlag = false;
    }
}
