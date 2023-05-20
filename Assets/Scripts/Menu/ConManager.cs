using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ConManager : MonoBehaviour
{
    [SerializeField] Animator openAnim;

    // メニューが開いているかのフラグ
    public static bool conFlag;

    // メニューを開くことができるかどうかのフラグ
    public static bool Openmenu;
    // Openmenuを時間で管理するための変数
    int timer;
    // メニューとメニュー背景をコンポーネント
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject menuBack;

    public static bool concon;
    // Start is called before the first frame update
    void Start()
    {
        // 変数の初期化
        conFlag = false;
        Openmenu = true;
    }

    // Update is called once per frame
    void Update()
    {
        // シーン遷移中は選択不能にする
        if (FadeManager.alpha != 0 && FadeManager.alpha != 1)
        {
            conFlag = false;
            Openmenu = false;
            menuBack.SetActive(conFlag);
        }

        if (Openmenu)
        {
            if (MenuController.endFlag)
            {
                Debug.Log("きちゃ");

                // フラグ反転
                Openmenu = false;
                conFlag = !conFlag;
                concon = true;

                // アニメーション開始
                openAnim.enabled = true;

                // アニメーションにフラグをセット
                openAnim.SetBool("menuFlagAnim", conFlag);

                // メニューを非アクティブ
                menuBack.SetActive(conFlag);

                MenuController.endFlag = false;
            }
            
        }

        //　0.5秒のクールタイム
        if (!Openmenu)
        {
            timer++;
        }
        if (timer > 30)
        {
            Openmenu = true;
            timer = 0;
        }
        else if (!conFlag)
        {
            Openmenu = true;

        }
    }
}
