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
        
    void Start()
    {
        fadeManager.FadeIn();

        fadeFlag = false;
    }

    void Update()
    {
        // �t�F�[�h���ɃX�y�[�X�������Ȃ�����
        if (FadeManager.alpha != 0.0f && FadeManager.alpha != 1.0f) return;

        if(Input.GetKeyDown(KeyCode.Space))
        {

            if (MenuManager.menuFlag) { return; }
           
            // �t�F�[�h�A�E�g
            fadeManager.FadeOut();
            
            fadeFlag = true;
        }

        // �t�F�[�h�A�E�g���I�������V�[���ǂݍ���
        if (fadeFlag && fadeManager.Alpha() >= 1.0f)
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}
