using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �V�[���J��
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // �v���n�u�������L�����o�X������
    GameObject fadeCanvas;
    [SerializeField]
    FadeManager fadeManager;

    // �V�[���̖��O
    [SerializeField]
    [Header("���̃V�[���̖��O������")]
    public string sceneName;

    bool fadeFlag;

    double endingTime;
        
    void Start()
    {
        fadeManager.FadeIn();

        fadeFlag = false;

        endingTime = (double)gameObject.GetComponent<RotCount>().GetCounter() + 600;
    }

    void Update()
    {
        // �t�F�[�h���ɃX�y�[�X�������Ȃ�����
        if (FadeManager.alpha != 0.0f && FadeManager.alpha != 1.0f) return;

        // �X�y�[�X��������Ă��ăG���f�B���O����Ȃ���Α���\
        if(Input.GetKeyDown(KeyCode.Space) && 
           SceneManager.GetActiveScene().name != "EndingScene")
        {
            if (MenuManager.menuFlag) { return; }

            // �V�[���J��
            NextScene();
        }

        // �t�F�[�h�A�E�g���I�������V�[���ǂݍ���
        if (fadeFlag && fadeManager.Alpha() >= 1.0f)
        {
            SceneManager.LoadScene(sceneName);
        }

        // Ending�Ȃ玩���őJ�ڂ���
        if (SceneManager.GetActiveScene().name == "EndingScene")
        {
            endingTime--;

            if (endingTime < 0)
            {
                // �V�[���J��
                NextScene();
            }
        }
        else
        {
            endingTime = (double)gameObject.GetComponent<RotCount>().GetCounter() + 600;
        }
    }

    // �V�[�������[�h����
    void NextScene()
    {
        // �t�F�[�h�A�E�g
        fadeManager.FadeOut();

        fadeFlag = true;
    }
}
