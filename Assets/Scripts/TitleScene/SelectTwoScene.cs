using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SelectTwoScene : MonoBehaviour
{
    // True�F���̃X�e�[�W�@False�F�Z���N�g�ɖ߂�
    bool is_SceneFlag;
    void Start()
    {
        is_SceneFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �t���O�̐؂�ւ�
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
                // ���̃X�e�[�W
            }
            else
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }
}
