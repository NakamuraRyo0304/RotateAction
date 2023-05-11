using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �V�[���J��
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class SceneController : MonoBehaviour
{
    // �v���n�u�������L�����o�X������
    public GameObject fadeCanvas;

    // �V�[���̖��O
    [SerializeField]
    [Header("���̃V�[���̖��O������")]
    public string sceneName;

        
    void Start()
    {
        // �N�����č쐬
        if(!FadeManager.is_FadeInstance)
        {
            Instantiate(fadeCanvas);
        }
        // �t�F�[�h�C��
        StartFadeIn();
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) || MenuController.menuSelectFlag == true)
        {
            if (MenuManager.menuFlag) { return; }

            // �t�F�[�h�A�E�g
            fadeCanvas.GetComponent<FadeManager>().FadeOut();
        }

        // �t�F�[�h�A�E�g���I�������V�[���ǂݍ���
        if (fadeCanvas.GetComponent<FadeManager>().Alpha() == 1.0f)
        {
            SceneManager.LoadScene(sceneName);
            MenuController.menuSelectFlag = false;
        }
    }

    void StartFadeIn()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");
        // �����ăt�F�[�h�X�^�[�g
        fadeCanvas.GetComponent<FadeManager>().FadeIn();
    }
}
