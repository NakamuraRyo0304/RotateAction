using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    // �t�F�[�h�֘A
    // �v���n�u�������L�����o�X������
    GameObject fadeCanvas;
    [SerializeField]
    FadeManager fadeManager;
    bool fadeFlag;

    // ���j���[�őI�΂ꂽ�̂��𔻕ʂ���t���O
    bool selectFlag = false;
    bool endFlag = false;

    // ���j���[�̂ǂ���I�����Ă��邩�̔���
    public static int menuNum;
    public static bool menuSelectFlag;

    // �I�����Ă��郁�j���[�ɂ���ĉ�N�̈ʒu�ύX�p�x�N�^�[
    Vector2[] playerPos = new Vector2[4];
    // �L�[���͂ɂ���ăA�N�e�B�u���Ǘ����邽�߂�SerializeField
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject menuBack;

    // �A�j���[�V�����p�ϐ�
    int menuNumAnim;
    // �A�j���[�V�������󂯎��
    [SerializeField]
    Animator AnimSelect;
    [SerializeField]
    Animator AnimOpen;
    [SerializeField]
    Animator menuExp;

    // Start is called before the first frame update
    void Start()
    {
        // �ϐ��̏�����
        menuNum = 1;
        menuSelectFlag = false;
        playerPos[0] = new Vector2(0.0f, 1.78f);
        playerPos[1] = new Vector2(0.0f, 0.138f);
        playerPos[2] = new Vector2(0.0f, -0.831f);
        playerPos[3] = new Vector2(0.0f, -2.612f);

        menuNumAnim = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // ���^�[������Ȃ��悤�ɏ�ŌĂ�
        if (selectFlag)
        {
            Select();
        } 
        if (endFlag)
        {
            End();
        }

        if (!MenuManager.menuFlag) { return; }

        // ���݂̃A�j���[�V�����̃p�����[�^�̒l���󂯎��
        //menuNumAnim = AnimSelect.GetInteger("menuNum");

        // �e�ϐ��̃N�����v�@���̓��j���[�̑I���ł��鐔
        menuNum = Mathf.Clamp(menuNum, 1, 4);
        menuNumAnim = Mathf.Clamp(menuNum, 1, 4);

        // �I�����Ă��郁�j���[�ɂ���ĉ�N�̈ʒu�ύX
        this.transform.position = playerPos[menuNum - 1];

        // �l�̉��Z
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            menuNum--;
            menuNumAnim--;
        }
        // �l�̌��Z
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            menuNum++;
            menuNumAnim++;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (menuNum == 3)
            {
                selectFlag = true;
            }


            if (menuNum == 4)
            {
                endFlag = true;

            }
        }

        // �A�j���[�V�����̃p�����[�^�[��ݒ肷��
        AnimSelect.SetInteger("menuNum", menuNumAnim);
    }

    void Select()
    {
        // �t�F�[�h�A�E�g
        fadeManager.FadeOut();

        fadeFlag = true;

        // �t�F�[�h�A�E�g���I�������V�[���ǂݍ���
        if (fadeFlag && fadeManager.Alpha() >= 1.0f)
        {
            SceneManager.LoadScene("SelectScene");


            // ���j���[�̑I������ԏ�ɖ߂�
            menuNum = 1;
            AnimOpen.SetBool("menuFlagAnim", MenuManager.menuFlag);
            menuExp.SetBool("menuFlagAnim", MenuManager.menuFlag);

        }
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
