using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterGoal : MonoBehaviour
{
    // フェードオブジェクトを入れる
    private GameObject fadeCanvas;

    // クリアテクスチャ
    [SerializeField]
    GameObject clearTexture;

    // 何を選んでいるかの判定用変数
    int menuNum = 1;

    bool selectFlag = false;
    bool nextFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        // フェード用キャンバスを受け取る
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");
    }

    // Update is called once per frame
    void Update()
    {
        menuNum = Mathf.Clamp(menuNum, 1, 2);

        // ゴールした時に関数を呼び出す
        if (Goal.isGoalFlag) 
        {
            transform.position += new Vector3(0.0f, -0.1f, 0.0f);

            if(transform.position.y <= 0.0f) 
            {
                transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            }
            DrawClear();
            AfterClear();
            select();
            next();
        }

    }

    // テクスチャ表示
    void DrawClear()
    {
        clearTexture.SetActive(true);
    }

    // シーン遷移
    void AfterClear()
    {
        // 左右キーで遷移先を決める
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            menuNum++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            menuNum--;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // １の時はセレクト
            if (menuNum == 1)
            {
                selectFlag = true;   
            }

            // ２の時は次にステージ
            if (menuNum == 2)
            {
                nextFlag = true;
                StageSelect.StageNum++;
            }
        }
    }

    void select()
    {
        if (!selectFlag) return;

        fadeCanvas.GetComponent<FadeManager>().FadeOut();

        if (fadeCanvas.GetComponent<FadeManager>().Alpha() >= 0.9f)
        {
            SceneManager.LoadScene("SelectScene");
        }
    }   
    void next()
    {
        if (!nextFlag) return;

        fadeCanvas.GetComponent<FadeManager>().FadeOut();
        Debug.Log("ちんちんﾁｮｷﾁｮｷたーいむ");

        if (fadeCanvas.GetComponent<FadeManager>().Alpha() >= 0.9f)
        {
            SceneManager.LoadScene("PlayScene");
        }
    }
}
