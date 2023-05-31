using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// シーン遷移
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // プレハブ化したキャンバスを入れる
    GameObject fadeCanvas;
    [SerializeField]
    FadeManager fadeManager;

    // シーンの名前
    [SerializeField]
    [Header("次のシーンの名前を入れる")]
    public string sceneName;

    bool fadeFlag;

        
    void Start()
    {
        fadeManager.FadeIn();

        fadeFlag = false;
    }

    void Update()
    {
        // フェード中にスペースを押せなくする
        if (FadeManager.alpha != 0.0f && FadeManager.alpha != 1.0f) return;

        // スペースを押されていてエンディングじゃなければ操作可能
        if(Input.GetKeyDown(KeyCode.Space) && 
           SceneManager.GetActiveScene().name != "EndingScene")
        {
            if (MenuManager.menuFlag) { return; }

            // シーン遷移
            NextScene();
        }

        // フェードアウトが終わったらシーン読み込み
        if (fadeFlag && fadeManager.Alpha() >= 1.0f)
        {
            SceneManager.LoadScene(sceneName);
        }

        // Endingなら自動で遷移する
        if (SceneManager.GetActiveScene().name == "EndingScene")
        {
            EndingManager.endingTime--;

            if (EndingManager.endingTime < 0)
            {
                // シーン遷移
                NextScene();
            }

            if(EndingManager.canTitleFlag)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    // シーン遷移
                    NextScene();
                }
            }
        }
    }

    // シーンをロードする
    void NextScene()
    {
        // フェードアウト
        fadeManager.FadeOut();

        fadeFlag = true;
    }
}
