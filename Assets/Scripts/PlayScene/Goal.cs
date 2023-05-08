using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    // �t�F�[�h�I�u�W�F�N�g������
    private GameObject fadeCanvas;

    // �S�[������
    public static bool isGoalFlag = false;

    void Start()
    {
        // �I�ǋL---------------------------------------------------
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");
        // �����ăt�F�[�h�X�^�[�g
        fadeCanvas.GetComponent<FadeManager>().FadeIn();

        isGoalFlag = false;
        //----------------------------------------------------------
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            isGoalFlag = true;
        }
    }

    // �I�ǋL
    void Update()
    {
        // FIXED: ���݁A�S�[�������u�ԃt�F�[�h�A�E�g���n�܂�
        if (isGoalFlag)
        {
            // �t�F�[�h�A�E�g
            fadeCanvas.GetComponent<FadeManager>().FadeOut();
        }

        // FIXED: ���݁A�t�F�[�h�A�E�g���I�������Z���N�g�ɖ߂�悤�ɂȂ��Ă���
        if (fadeCanvas.GetComponent<FadeManager>().Alpha() == 1.0f)
        {
            SceneManager.LoadScene("SelectScene");
        }
    }
}
