using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    // フェード関連
    // プレハブ化したキャンバスを入れる
    GameObject fadeCanvas;
    [SerializeField]
    FadeManager fadeManager;
    bool fadeFlag;

    // メニューで選ばれたのもを判別するフラグ
    bool selectFlag = false;
    bool endFlag = false;

    // メニューのどこを選択しているかの判定
    public static int menuNum;
    public static bool menuSelectFlag;

    // 選択しているメニューによって廻君の位置変更用ベクター
    Vector2[] playerPos = new Vector2[4];
    // キー入力によってアクティブを管理するためのSerializeField
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject menuBack;

    // アニメーション用変数
    int menuNumAnim;
    // アニメーションを受け取る
    [SerializeField]
    Animator AnimSelect;
    [SerializeField]
    Animator AnimOpen;
    [SerializeField]
    Animator menuExp;

    // Start is called before the first frame update
    void Start()
    {
        // 変数の初期化
        menuNum = 1;
        menuSelectFlag = false;
        playerPos[0] = new Vector2(0.0f, 1.78f);
        playerPos[1] = new Vector2(0.0f, 0.138f);
        playerPos[2] = new Vector2(0.0f, -0.831f);
        playerPos[3] = new Vector2(0.0f, -2.612f);

        menuNumAnim = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // リターンされないように上で呼ぶ
        if (selectFlag)
        {
            Select();
        } 
        if (endFlag)
        {
            End();
        }

        if (!MenuManager.menuFlag) { return; }

        // 現在のアニメーションのパラメータの値を受け取る
        //menuNumAnim = AnimSelect.GetInteger("menuNum");

        // 各変数のクランプ　数はメニューの選択できる数
        menuNum = Mathf.Clamp(menuNum, 1, 4);
        menuNumAnim = Mathf.Clamp(menuNum, 1, 4);

        // 選択しているメニューによって廻君の位置変更
        this.transform.position = playerPos[menuNum - 1];

        // 値の加算
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            menuNum--;
            menuNumAnim--;
        }
        // 値の減算
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            menuNum++;
            menuNumAnim++;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (menuNum == 3)
            {
                selectFlag = true;
            }


            if (menuNum == 4)
            {
                endFlag = true;

            }
        }

        // アニメーションのパラメーターを設定する
        AnimSelect.SetInteger("menuNum", menuNumAnim);
    }

    void Select()
    {
        // フェードアウト
        fadeManager.FadeOut();

        fadeFlag = true;

        // フェードアウトが終わったらシーン読み込み
        if (fadeFlag && fadeManager.Alpha() >= 1.0f)
        {
            SceneManager.LoadScene("SelectScene");


            // メニューの選択を一番上に戻す
            menuNum = 1;
            AnimOpen.SetBool("menuFlagAnim", MenuManager.menuFlag);
            menuExp.SetBool("menuFlagAnim", MenuManager.menuFlag);

        }
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
