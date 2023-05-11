using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// シーン遷移
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // プレハブ化したキャンバスを入れる
    public GameObject fadeCanvas;
    FadeManager fadeManager;

    // シーンの名前
    [SerializeField]
    [Header("次のシーンの名前を入れる")]
    public string sceneName;

    bool fadeFlag;
        
    void Start()
    {

        // フェードイン
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");

        fadeManager = fadeCanvas.GetComponent<FadeManager>();

        fadeManager.FadeIn();

        Debug.Log("おおおおおちんちんﾁｮｷﾁｮｷたーいむ＾＾");

        fadeFlag = false;
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) || MenuController.menuSelectFlag == true)
        {
            if (MenuManager.menuFlag) { return; }

            fadeFlag = true;

            Debug.Log("おおおおおちんちんﾁｮｷﾁｮｷたーいむ＾＾");

        }

        if(fadeFlag)
        {
            // フェードアウト
            fadeManager.FadeOut();
        }

        // フェードアウトが終わったらシーン読み込み
        if (fadeManager.Alpha() >= 0.9f &&
            fadeFlag)
        {
            SceneManager.LoadScene(sceneName);
            MenuController.menuSelectFlag = false;
        }
    }
}
