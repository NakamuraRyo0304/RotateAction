using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotCount : MonoBehaviour
{
    private int rotCounter;
    void Start()
    {
        rotCounter = 0;
        DontDestroyOnLoad(this);
    }

    
    void Update()
    {
        // フェード中は操作不能にする
        if (FadeManager.alpha != 0.0f && FadeManager.alpha != 1.0f) return;

        // メニューを開いていたら処理しない
        if (MenuManager.menuFlag) return;

        // プレイシーン以外は処理しない
        if (SceneManager.GetActiveScene().name != "Playscene") return;

        // ゴールしたら処理しない
        if (Goal.isGoalFlag) return;

        // 死んでいたら処理しない
        if (PlayerController.deadFlag == true) return;

        // 回転数を加算する
        rotCounter += 1 * Rotate.rotFlagNum;
        Debug.Log("回転数：" + rotCounter);

        // タイトルでカウンタリセット
        if(SceneManager.GetActiveScene().name == "TitleScene")
        {
            rotCounter = 0;
        }
    }

    public int GetCounter()
    {
        return rotCounter;
    }
}
