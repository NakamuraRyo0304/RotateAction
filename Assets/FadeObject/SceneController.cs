using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// シーン遷移
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class SceneController : MonoBehaviour
{
    // プレハブ化したキャンバスを入れる
    public GameObject fadeCanvas;

    // シーンの名前
    [SerializeField]
    [Header("次のシーンの名前を入れる")]
    public string sceneName;

        
    void Start()
    {
        // 起動して作成
        if(!FadeManager.is_FadeInstance)
        {
            Instantiate(fadeCanvas);
        }
        // フェードイン
        StartFadeIn();
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) || MenuController.menuSelectFlag == true)
        {
            if (MenuManager.menuFlag) { return; }

            // フェードアウト
            fadeCanvas.GetComponent<FadeManager>().FadeOut();
        }

        // フェードアウトが終わったらシーン読み込み
        if (fadeCanvas.GetComponent<FadeManager>().Alpha() == 1.0f)
        {
            SceneManager.LoadScene(sceneName);
            MenuController.menuSelectFlag = false;
        }
    }

    void StartFadeIn()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");
        // 見つけてフェードスタート
        fadeCanvas.GetComponent<FadeManager>().FadeIn();
    }
}
