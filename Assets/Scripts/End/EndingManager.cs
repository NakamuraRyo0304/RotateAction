using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    [SerializeField]
    Sprite[] nums;

    public bool one_Flag = false;
    public bool ten_Flag = false;
    public bool han_Flag = false;
    public bool tho_Flag = false;

    double number;

    public static double endingTime;

    public static bool canTitleFlag;

    void Start()
    {
        // 数値の取得
        number = 0;

        endingTime = 6000;

        canTitleFlag = false;

        GameObject.Find("SE").gameObject.GetComponent<SoundManager>().ResetSound();
    }

    // Update is called once per frame
    void Update()
    {
        // フェード中は処理しない
        if (FadeManager.alpha != 0.0f && FadeManager.alpha != 1.0f) return;

        // カウントアップ
        if(number < (double)GameObject.FindGameObjectWithTag("RotateCounter").GetComponent<RotCount>().GetCounter()&&
           number != 9999)
        {
            number += 0.5;

            // 表示番号をクランプ
            if (number > 9999)
            {
                number = 9999;
            }
        }


        // スペース押せるフラグを立てる
        if(number == (double)GameObject.FindGameObjectWithTag("RotateCounter").GetComponent<RotCount>().GetCounter())
        {
            canTitleFlag = true;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            number = (double)GameObject.FindGameObjectWithTag("RotateCounter").GetComponent<RotCount>().GetCounter();
        }
        // 画像を設定
        if (one_Flag) 
        {
            SetNum((int)number % 10);
        }
        if(ten_Flag)
        {
            SetNum(((int)number / 10) % 10);
        }
        if(han_Flag)
        {
            SetNum(((int)number / 100) % 10);
        }
        if(tho_Flag)
        {
            SetNum(((int)number / 1000) % 10);
        }
    }

    void SetNum(int num)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = nums[num];
    }

}
