using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    int AreaNum;        // �G���A�ԍ�        �P�`�T
    int StageNum;       // �X�e�[�W�ԍ�      �P�`�T
    void Start()    
    {
        AreaNum = 1;
        StageNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // brief:�E�L�[�������Ɓ{/���L�[�������Ɓ[�@��) 3-1�E�L�[�@3-2�@/�@2-1���L�[�@1-5�@/�@2-5�E�L�[�@3-1

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(StageNum < 5)
            {
                StageNum++;
            }
            else if(AreaNum < 5)
            {
                StageNum = 1;
                AreaNum++;
            }
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(StageNum > 1)
            {
                StageNum--;
            }
            else if(AreaNum > 1)
            {
                StageNum = 5;
                AreaNum--;
            }
        }
    }
}
