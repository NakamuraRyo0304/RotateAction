using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // メニューのどこを選択しているかの判定
    public static int menuNum;

    // 選択しているメニューによって廻君の位置変更用ベクター
    Vector2[] playerPos = new Vector2[3];
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
        playerPos[0] = new Vector2(0.0f, 0.865f);
        playerPos[1] = new Vector2(0.0f, -0.678f);
        playerPos[2] = new Vector2(0.0f, -1.803f);

        menuNumAnim = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!MenuManager.menuFlag) { return; }

        // 現在のアニメーションのパラメータの値を受け取る
        //menuNumAnim = AnimSelect.GetInteger("menuNum");

        // 各変数のクランプ　数はメニューの選択できる数
        menuNum = Mathf.Clamp(menuNum, 1, 3);
        menuNumAnim = Mathf.Clamp(menuNum, 1, 3);

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
                // ゲーム終了
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif
            }

            // メニューの選択を一番上に戻す
            menuNum = 1;
            AnimOpen.SetBool("menuFlagAnim", MenuManager.menuFlag);
            menuExp.SetBool("menuFlagAnim", MenuManager.menuFlag);

        }
            // アニメーションのパラメーターを設定する
            AnimSelect.SetInteger("menuNum", menuNumAnim);
    }
}
