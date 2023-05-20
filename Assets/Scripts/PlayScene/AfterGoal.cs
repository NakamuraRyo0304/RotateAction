using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterGoal : MonoBehaviour
{
    // プレハブ化したキャンバスを入れる
    GameObject fadeCanvas;
    [SerializeField]
    FadeManager fadeManager;

    // クリアテクスチャ
    [SerializeField]
    GameObject charTexture;

    bool menuFlag = false;
    bool selectFlag = false;
    bool nextFlag = false;

    // 何を選んでいるかの判定用変数
    int menuNum = 1;

    bool fadeFlag;

    // 決定済みか判定するフラグ
    public static bool decideFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        fadeManager.FadeIn();

        fadeFlag = false;
        decideFlag = false;
        
        Goal.isGoalFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        menuNum = Mathf.Clamp(menuNum, 1, 2);

        // ゴールした時に関数を呼び出す
        if (Goal.isGoalFlag) 
        {
            transform.position += new Vector3(0.0f, -0.1f, 0.0f);
            //charTexture.transform.position += new Vector3(0.0f, -0.1f, 0.0f);

            if(transform.position.y <= 2.5f) 
            {
                transform.position = new Vector3(0.0f, 2.5f, 0.0f);
            }

            // 矢印押したらスキップ
            if(Input.GetKeyDown(KeyCode.RightArrow)||
                Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position = new Vector3(0.0f, 2.5f, 0.0f);
            }

            //if(charTexture.transform.position.y <= -1.5)
            //{
            //    charTexture.transform.position = new Vector3(0.0f, -1.55f, 0.0f);
            //}

            // メニューが開いていたら処理しない
            if (MenuManager.menuFlag) return;

            AfterClear();
            CharPos();

            if(selectFlag) 
                select();
            if(nextFlag)
            {
                // 通常
                if (StageSelect.StageNum != StageSelect.MaxNum)
                {
                    next();
                }
                // 最終ステージにだったらタイトルに戻す(時間があればリザルトにする)
                else
                {
                    AllClear();
                }
            }
        }
        else
        {
            decideFlag = false;
        }
    }

    // シーン遷移
    void AfterClear()
    {
        if (transform.position.y != 2.5f) return;

        // 左右キーで遷移先を決める
        if (Input.GetKeyDown(KeyCode.RightArrow) && !decideFlag) 
        {
            menuNum++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !decideFlag) 
        {
            menuNum--;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            decideFlag = true;

            // １の時はセレクト
            if (menuNum == 1)
            {
                selectFlag = true;
            }

            // ２の時は次にステージ
            if (menuNum == 2)
            {
                StageSelect.StageNum++;

                // 45超えたらクランプ
                if(StageSelect.StageNum >= 45)
                {
                    StageSelect.StageNum = 45;
                }

                nextFlag = true;

                // エリア移動用関数
                SelectStageMove();
            }
        }
    }

    void CharPos()
    {
        // 決定していたら処理しない
        if (decideFlag) return;


        if (menuNum == 1 && menuFlag == true)
        {
            charTexture.transform.position = new Vector3(-4.0f, -1.55f, 0.0f);
        }

        // ２の時は次にステージ
        if (menuNum == 2)
        {
            menuFlag = true;
            charTexture.transform.position = new Vector3(4.0f, -1.55f, 0.0f);
        }
    }

    void select()
    {
        if (MenuManager.menuFlag) { return; }

        // フェードアウト
        fadeManager.FadeOut();

        fadeFlag = true;


        // フェードアウトが終わったらシーン読み込み
        if (fadeFlag && fadeManager.Alpha() >= 0.9f)
        {
            SceneManager.LoadScene("SelectScene");
        }
    }

    void next()
    {

        if (MenuManager.menuFlag) { return; }
        // フェードアウト
        fadeManager.FadeOut();

        fadeFlag = true;

        // フェードアウトが終わったらシーン読み込み
        if (fadeFlag && fadeManager.Alpha() >= 1.0f)
        {

            Debug.Log("きちゃ");
            SceneManager.LoadScene("PlayScene");
        }
    }

    void AllClear()
    {
        if (MenuManager.menuFlag) { return; }
        // フェードアウト
        fadeManager.FadeOut();

        fadeFlag = true;

        // フェードアウトが終わったらシーン読み込み
        if (fadeFlag && fadeManager.Alpha() >= 1.0f)
        {
            // エンディングシーンに切り替え
            SceneManager.LoadScene("EndingScene");
        }
    }

    void SelectStageMove()
    {
        // 右へ遷移
        if (StageSelect.StageNum == 6 || StageSelect.StageNum == 11 || StageSelect.StageNum == 16 || StageSelect.StageNum == 21 ||
            StageSelect.StageNum == 26 || StageSelect.StageNum == 31 || StageSelect.StageNum == 36 || StageSelect.StageNum == 41)
        {
            MoveStage.savePos.x -= 20;
        }
    }
}
