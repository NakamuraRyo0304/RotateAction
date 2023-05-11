using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterGoal : MonoBehaviour
{
    // フェードオブジェクトを入れる
    private GameObject fadeCanvas;

    [SerializeField]
    GameObject clearTexture;

    int menuNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");
    }

    // Update is called once per frame
    void Update()
    {
        menuNum = Mathf.Clamp(menuNum, 1, 2);
        if (Goal.isGoalFlag) 
        {
            DrawClear();
            AfterClear();
        }

    }

    void DrawClear()
    {
        clearTexture.SetActive(true);
    }

    void AfterClear()
    {
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
            if (menuNum == 1)
            {
                fadeCanvas.GetComponent<FadeManager>().FadeOut();

                if (fadeCanvas.GetComponent<FadeManager>().Alpha() == 1.0f)
                {
                    SceneManager.LoadScene("SelectScene");
                }
            }
            if (menuNum == 2)
            {
                StageSelect.StageNum++;
                fadeCanvas.GetComponent<FadeManager>().FadeOut();

                if (fadeCanvas.GetComponent<FadeManager>().Alpha() == 1.0f)
                {
                    SceneManager.LoadScene("PlayScene");
                }
            }
        }
    }
}
