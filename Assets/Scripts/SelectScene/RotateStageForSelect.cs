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
        //�@�I��ł�Ƃ��͉�]
        Stage[StageSelect.StageNum - 1].transform.Rotate(0, 0, 1);

        //�@�Z���N�g�؂�ւ��ŉ�]�ʃ��Z�b�g
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
