using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorTextureChange : MonoBehaviour
{
    // 初期状態
    public Sprite lockImage;
    // 解除状態
    public Sprite unlockImage;

    // 画像描画用のコンポーネント
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
