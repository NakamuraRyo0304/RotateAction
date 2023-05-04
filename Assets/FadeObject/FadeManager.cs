using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    // フェードの速度
    [SerializeField]
    [Header("フェード速度")] float speed = 0.01f;

    float red, green, blue, alpha;

    [SerializeField]
    [Header("フェードイン")] bool is_In = false;

    [SerializeField]
    [Header("フェードアウト")] bool is_Out = false;


    public int Is_OutAlpha
    {
        get
        {
            return (int)alpha;
        }
        set
        {
            alpha = 0;
            is_Out = true;
        }
    }
    public int Is_InAlpha
    {
        get
        {
            return (int)alpha;
        }
        set
        {
            alpha = 1;
            is_In = true;
        }
    }

    [SerializeField]
    [Header("フェード使用時:True")]  bool is_Active = false;
    
    // パネルイメージ
    Image fadeImage;


    void Start()
    {
        this.gameObject.SetActive(is_Active);
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alpha = fadeImage.color.a;
    }

    void Update()
    {
        if(is_In)
        {
            FadeIn();
        }
        if(is_Out)
        {
            FadeOut();
        }
    }


    void FadeIn()
    {
        alpha -= speed;
        Alpha();

        if(alpha <= 0)
        {
            is_In = false;
            fadeImage.enabled = false;
        }
    }

    void FadeOut()
    {
        fadeImage.enabled = true;
        alpha += speed;
        Alpha();

        if(alpha >= 1)
        {
            is_Out = false;
        }
    }

    void Alpha()
    {
        fadeImage.color = new Color(red, green, blue, alpha);
    }
}
