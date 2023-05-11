using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UIの追加
using UnityEngine.UI;


public class FadeManager : MonoBehaviour
{
    // フェードオブジェクトを生成するフラグ
    public static bool is_FadeInstance = false;

    // フェードインのフラグ
    public bool is_FadeIn              = false;
    // フェードアウトのフラグ
    public bool is_FadeOut             = false;

    // 透明度(これが変化してフェードになる)
    public float alpha                 = 0.0f;
    // フェードにかかる時間
    public float fadeTime              = 0.0f;

    void Start()
    {
        // 一番初めに起動した時作成(破壊不能オブジェクトに設定)
        if (!is_FadeInstance)
        {
            is_FadeInstance = true;
        }
    }

    void Update()
    {
        // フェードインの処理
        if(is_FadeIn)
        {
            // フェード処理
            alpha -= Time.deltaTime / fadeTime;
            alpha -= Time.deltaTime / fadeTime;
            
            // 透明になったら処理終了
            if(alpha <= 0.0f)
            {
                is_FadeIn = false;
                alpha = 0.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }

        // フェードアウト処理
        else if(is_FadeOut)
        {
            // フェード処理
            alpha += Time.deltaTime / fadeTime;

            // 暗転したら処理終了
            if(alpha >= 1.0f)
            {
                is_FadeOut = false;
                alpha = 1.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
    }

    // 以下、呼び出し用関数
    public void FadeIn()
    {
        is_FadeIn = true;
        is_FadeOut = false;
    }

    public void FadeOut()
    {
        is_FadeIn = false;
        is_FadeOut = true;
    }

    public float Alpha()
    {
        return alpha;
    }
}
