using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    // インスタンス生成
    public static StageSelect instance;

    public static int StageNum = 1;
    public static int MaxNum = 45;

    public static bool decideFlag;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()    
    {
        decideFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        // フェード中は処理しない
        if (FadeManager.alpha != 0.0f && FadeManager.alpha != 1.0f) return;

        // メニューフラグがたっていたら処理しない
        if (MenuManager.menuFlag) return;

        // 決定フラグがたってたら処理しない
        if (decideFlag) return;

        if (MoveStage.MoveFlag) return;

        // brief:右キーを押すと＋/左キーを押すとー　例) 3-1右キー　3-2　/　2-1左キー　1-5　/　2-5右キー　3-1

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(StageNum < MaxNum)
            {
                StageNum++;
            }
            Debug.Log(StageNum);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(StageNum > 1)
            {
                StageNum--;
            }
            Debug.Log(StageNum);
        }

        // エリア移動
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(StageNum < MaxNum)
            {
                StageNum += 5;
                Debug.Log(StageNum);
            }
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(StageNum > 5)
            {
                StageNum -= 5;
                Debug.Log(StageNum);
            }
        }

        // クランプ処理
        StageNum = Mathf.Clamp(StageNum, 1, MaxNum);

        // 決定する
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            decideFlag = true;
        }
    }
}
