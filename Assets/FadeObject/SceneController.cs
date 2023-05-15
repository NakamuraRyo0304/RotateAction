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

        Debug.Log("ちょきちょきScene");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            if (MenuManager.menuFlag) { return; }
           
            // フェードアウト
            fadeManager.FadeOut();
            
            fadeFlag = true;
        }

        // フェードアウトが終わったらシーン読み込み
        if (fadeFlag && fadeManager.Alpha() >= 1.0f)
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}
