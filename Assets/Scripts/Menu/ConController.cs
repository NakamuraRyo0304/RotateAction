using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ConController : MonoBehaviour
{
    // フェード関連
    // プレハブ化したキャンバスを入れる
    GameObject fadeCanvas;
    [SerializeField]
    FadeManager fadeManager;
    bool fadeFlag;

    // メニューのどこを選択しているかの判定
    public static int menuNum;
    bool endFlag = false;

    // 選択しているメニューによって廻君の位置変更用ベクター
    Vector2[] playerPos = new Vector2[2];
    // キー入力によってアクティブを管理するためのSerializeField
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject menuBack;

    // アニメーション用変数
    int menuNumAnim;
    // アニメーションを受け取る
    //[SerializeField]
    //Animator AnimSelect;
    [SerializeField]
    Animator AnimOpen;


    // Start is called before the first frame update
    void Start()
    {
        // 変数の初期化
        menuNum = 1;
        playerPos[0] = new Vector2(-2.5f, -0.97f);
        playerPos[1] = new Vector2(2.5f, -0.97f);

        menuNumAnim = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (endFlag)
        {
            End();
        }

        if (!ConManager.conFlag) { return; }

        // 現在のアニメーションのパラメータの値を受け取る
        //menuNumAnim = AnimSelect.GetInteger("menuNum");

        // 各変数のクランプ　数はメニューの選択できる数
        menuNum = Mathf.Clamp(menuNum, 1, 2);
        menuNumAnim = Mathf.Clamp(menuNum, 1, 2);

        // 選択しているメニューによって廻君の位置変更
        this.transform.position = playerPos[menuNum - 1];

        // 値の加算
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            menuNum--;
            menuNumAnim--;
        }
        // 値の減算
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            menuNum++;
            menuNumAnim++;
        }
        if (ConManager.conFlag && !ConManager.concon)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (menuNum == 1)
                {
                    MenuController.endFlag = false;
                    ConManager.conFlag = false;

                    // メニューを非アクティブ
                    menuBack.SetActive(ConManager.conFlag);

                }
                if (menuNum == 2)
                {
                    endFlag = true;
                }

                AnimOpen.SetBool("menuFlagAnim", ConManager.conFlag);

            }


        }
        if (ConManager.concon)
        {
            ConManager.concon = false;
        }
        
        // アニメーションのパラメーターを設定する
        //AnimSelect.SetInteger("menuNum", menuNumAnim);
    }

    void End()
    {
        // フェードアウト
        fadeManager.FadeOut();

        fadeFlag = true;

        // フェードアウトが終わったらシーン読み込み
        if (fadeFlag && fadeManager.Alpha() >= 1.0f)
        {
            // ゲーム終了
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif
        }
    }
}

