using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Animator anim;

    // メニューが開いているかのフラグ
    public static bool menuFlag;

    // メニューを開くことができるかどうかのフラグ
    bool Openmenu;
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
        // シーン間でオブジェクトを破壊しない
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Openmenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // フラグ反転
                Openmenu = false;
                menuFlag = !menuFlag;
                anim.enabled = true;

                anim.SetBool("menuFlagAnim", menuFlag);

                // メニューを非アクティブ
                //menu.SetActive(true);
                menuBack.SetActive(menuFlag);

                // メニューで選ばれているところをリセット
                MenuController.menuNum = 1;
            }
        }

        //　1秒のクールタイム
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
