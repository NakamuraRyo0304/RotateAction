using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    // フェードオブジェクトを入れる
    private GameObject fadeCanvas;

    // ゴール判定
    public static bool isGoalFlag = false;

    void Start()
    {
        // ！追記---------------------------------------------------
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");
        // 見つけてフェードスタート
        fadeCanvas.GetComponent<FadeManager>().FadeIn();

        isGoalFlag = false;
        //----------------------------------------------------------
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            isGoalFlag = true;
        }
    }

    // ！追記
    void Update()
    {
        // FIXED: 現在、ゴールした瞬間フェードアウトが始まる
        if (isGoalFlag)
        {
            // フェードアウト
            fadeCanvas.GetComponent<FadeManager>().FadeOut();
        }

        // FIXED: 現在、フェードアウトが終わったらセレクトに戻るようになっている
        if (fadeCanvas.GetComponent<FadeManager>().Alpha() == 1.0f)
        {
            SceneManager.LoadScene("SelectScene");
        }
    }
}
