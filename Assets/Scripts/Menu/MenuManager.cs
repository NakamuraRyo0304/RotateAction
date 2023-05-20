using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Animator openAnim;
    [SerializeField] Animator menuExp;

    // メニューが開いているかのフラグ
    public static bool menuFlag;

    // メニューを開くことができるかどうかのフラグ
    public static bool Openmenu;
    // Openmenuを時間で管理するための変数
    int timer;
    // メニューとメニュー背景をコンポーネント
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject menuBack;

    // Start is called before the first frame update
    void Start()
    {
        // 変数の初期化
        menuFlag = false;
        Openmenu = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(ConController.endFlag && ConController.closeFlag)
        {
            menuExp.SetBool("menuFlagAnim", false);
            openAnim.SetBool("menuFlagAnim", false);
            menuBack.SetActive(false);
        }

        // シーン遷移中は選択不能にする
        if (FadeManager.alpha != 0 && FadeManager.alpha != 1)
        {
            menuFlag = false;
            Openmenu = false;
            menuBack.SetActive(menuFlag);
        }

        if (Openmenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (ConManager.conFlag) { return; }

                // フラグ反転
                Openmenu = false;
                menuFlag = !menuFlag;

                // アニメーション開始
                openAnim.enabled = true;
                menuExp.enabled = true;

                // アニメーションにフラグをセット
                menuExp.SetBool("menuFlagAnim", menuFlag);
                openAnim.SetBool("menuFlagAnim", menuFlag);

                // メニューを非アクティブ
                menuBack.SetActive(menuFlag);

                // メニューで選ばれているところをリセット
                MenuController.menuNum = 1;
            }
        }

        //　0.5秒のクールタイム
        if(!Openmenu) 
        {
            timer++;
        }
        if (timer  > 30)
        {
            Openmenu = true;
            timer = 0;
        }
        else if (!menuFlag)
        {
            Openmenu = true;

        }
    }
}
