using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SelectTwoScene : MonoBehaviour
{
    // True：次のステージ　False：セレクトに戻る
    bool is_SceneFlag;
    void Start()
    {
        is_SceneFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        // フラグの切り替え
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            is_SceneFlag = true;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            is_SceneFlag = false;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(is_SceneFlag)
            {
                // 次のステージ
            }
            else
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }
}
