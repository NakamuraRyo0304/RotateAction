using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterGoal : MonoBehaviour
{
    // フェードオブジェクトを入れる
    //private GameObject fadeCanvas;

    // クリアテクスチャ
    [SerializeField]
    GameObject charTexture;

    bool selectFlag = false;

    // 何を選んでいるかの判定用変数
    int menuNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        // フェード用キャンバスを受け取る
        //fadeCanvas = GameObject.FindGameObjectWithTag("Fade");
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

            //if(charTexture.transform.position.y <= -1.5)
            //{
            //    charTexture.transform.position = new Vector3(0.0f, -1.55f, 0.0f);
            //}
            AfterClear();
            CharPos();
        }

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
                select();
            }

            // ２の時は次にステージ
            if (menuNum == 2)
            {
                StageSelect.StageNum++;
                next();
            }
        }
    }

    void CharPos()
    {
        if (menuNum == 1 && selectFlag == true)
        {
            charTexture.transform.position = new Vector3(-4.0f, -1.55f, 0.0f);
        }

        // ２の時は次にステージ
        if (menuNum == 2)
        {
            selectFlag = true;
            charTexture.transform.position = new Vector3(4.0f, -1.55f, 0.0f);
        }
    }

    void select()
    {
        //if (!selectFlag) return;

        //fadeCanvas.GetComponent<FadeManager>().FadeOut();

        //if (fadeCanvas.GetComponent<FadeManager>().Alpha() >= 0.9f)
        //{
        //    SceneManager.LoadScene("SelectScene");
        //}
        SceneManager.LoadScene("SelectScene");
    }   
    void next()
    {
        //if (!nextFlag) return;

        //fadeCanvas.GetComponent<FadeManager>().FadeOut();
        //Debug.Log("ちんちんﾁｮｷﾁｮｷたーいむ");

        //if (fadeCanvas.GetComponent<FadeManager>().Alpha() >= 0.9f)
        //{
        //    SceneManager.LoadScene("PlayScene");
        //}
        SceneManager.LoadScene("PlayScene");
    }
}
