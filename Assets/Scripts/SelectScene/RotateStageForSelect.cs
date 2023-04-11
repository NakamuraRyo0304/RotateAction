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
        //　選んでるときは回転
        Stage[StageSelect.StageNum - 1].transform.Rotate(0, 0, 1);

        //　セレクト切り替えで回転量リセット
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            for (int num = 0; num < StageSelect.StageNum; num++)
            {
                if (StageSelect.StageNum - 1 == num) return;
                Stage[num].transform.rotation = Quaternion.identity;
            }            
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            for (int num = StageSelect.StageNum; num > 0; num--)
            {
                if (StageSelect.StageNum - 1 == num) return;
                Stage[num].transform.rotation = Quaternion.identity;
            }            
        }
    }
}
