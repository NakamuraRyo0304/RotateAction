using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �V�[���J��
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // �v���n�u�������L�����o�X������
    public GameObject fadeCanvas;
    FadeManager fadeManager;

    // �V�[���̖��O
    [SerializeField]
    [Header("���̃V�[���̖��O������")]
    public string sceneName;

    bool fadeFlag;
        
    void Start()
    {

        // �t�F�[�h�C��
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");

        fadeManager = fadeCanvas.GetComponent<FadeManager>();

        fadeManager.FadeIn();

        Debug.Log("�������������񂿂����������[���ށO�O");

        fadeFlag = false;
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) || MenuController.menuSelectFlag == true)
        {
            if (MenuManager.menuFlag) { return; }

            fadeFlag = true;

            Debug.Log("�������������񂿂����������[���ށO�O");

        }

        if(fadeFlag)
        {
            // �t�F�[�h�A�E�g
            fadeManager.FadeOut();
        }

        // �t�F�[�h�A�E�g���I�������V�[���ǂݍ���
        if (fadeManager.Alpha() >= 0.9f &&
            fadeFlag)
        {
            SceneManager.LoadScene(sceneName);
            MenuController.menuSelectFlag = false;
        }
    }
}
