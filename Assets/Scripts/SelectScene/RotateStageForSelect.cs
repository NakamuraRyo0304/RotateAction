using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStageForSelect : MonoBehaviour
{
    [SerializeField]GameObject[] Stage;
    void Start()
    {
    }

    void Update()
    {
        // メニューを開いているときは処理しない
        if (MenuManager.menuFlag) return;

        // フェード中は処理しない
        if (FadeManager.alpha != 0.0f && FadeManager.alpha != 1.0f) return;

        //　選んでるときは回転
        Stage[StageSelect.StageNum - 1].transform.Rotate(0, 0, 1);

        //　セレクト切り替えで回転量リセット
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            for (int num = 0; num < StageSelect.MaxNum; num++)
            {
                Stage[num].transform.rotation = Quaternion.identity;
            }            
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            for (int num = 0; num < StageSelect.MaxNum; num++)
            {
                Stage[num].transform.rotation = Quaternion.identity;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            for (int num = 0; num < StageSelect.MaxNum; num++)
            {
                Stage[num].transform.rotation = Quaternion.identity;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            for (int num = 0; num < StageSelect.MaxNum; num++)
            {
                Stage[num].transform.rotation = Quaternion.identity;
            }
        }
    }
}
