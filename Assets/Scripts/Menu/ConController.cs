using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ConController : MonoBehaviour
{
    // �t�F�[�h�֘A
    // �v���n�u�������L�����o�X������
    GameObject fadeCanvas;
    [SerializeField]
    FadeManager fadeManager;
    bool fadeFlag;

    // ���j���[�̂ǂ���I�����Ă��邩�̔���
    public static int menuNum;
    bool endFlag = false;

    // �I�����Ă��郁�j���[�ɂ���ĉ�N�̈ʒu�ύX�p�x�N�^�[
    Vector2[] playerPos = new Vector2[2];
    // �L�[���͂ɂ���ăA�N�e�B�u���Ǘ����邽�߂�SerializeField
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject menuBack;

    // �A�j���[�V�����p�ϐ�
    int menuNumAnim;
    // �A�j���[�V�������󂯎��
    //[SerializeField]
    //Animator AnimSelect;
    [SerializeField]
    Animator AnimOpen;


    // Start is called before the first frame update
    void Start()
    {
        // �ϐ��̏�����
        menuNum = 1;
        playerPos[0] = new Vector2(-2.5f, -0.97f);
        playerPos[1] = new Vector2(2.5f, -0.97f);

        menuNumAnim = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (endFlag)
        {
            End();
        }

        if (!ConManager.conFlag) { return; }

        // ���݂̃A�j���[�V�����̃p�����[�^�̒l���󂯎��
        //menuNumAnim = AnimSelect.GetInteger("menuNum");

        // �e�ϐ��̃N�����v�@���̓��j���[�̑I���ł��鐔
        menuNum = Mathf.Clamp(menuNum, 1, 2);
        menuNumAnim = Mathf.Clamp(menuNum, 1, 2);

        // �I�����Ă��郁�j���[�ɂ���ĉ�N�̈ʒu�ύX
        this.transform.position = playerPos[menuNum - 1];

        // �l�̉��Z
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            menuNum--;
            menuNumAnim--;
        }
        // �l�̌��Z
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            menuNum++;
            menuNumAnim++;
        }
        if (ConManager.conFlag && !ConManager.concon)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (menuNum == 1)
                {
                    MenuController.endFlag = false;
                    ConManager.conFlag = false;

                    // ���j���[���A�N�e�B�u
                    menuBack.SetActive(ConManager.conFlag);

                }
                if (menuNum == 2)
                {
                    endFlag = true;
                }

                AnimOpen.SetBool("menuFlagAnim", ConManager.conFlag);

            }


        }
        if (ConManager.concon)
        {
            ConManager.concon = false;
        }
        
        // �A�j���[�V�����̃p�����[�^�[��ݒ肷��
        //AnimSelect.SetInteger("menuNum", menuNumAnim);
    }

    void End()
    {
        // �t�F�[�h�A�E�g
        fadeManager.FadeOut();

        fadeFlag = true;

        // �t�F�[�h�A�E�g���I�������V�[���ǂݍ���
        if (fadeFlag && fadeManager.Alpha() >= 1.0f)
        {
            // �Q�[���I��
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif
        }
    }
}

