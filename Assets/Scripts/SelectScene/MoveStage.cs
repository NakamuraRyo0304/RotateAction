using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class MoveStage : MonoBehaviour
{
    // �C���X�^���X����
    public static MoveStage instance;

    int MoveX;
    public static bool MoveFlag;
    GameObject stageSelect;

    public static Vector3 savePos = Vector3.zero;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        MoveX = 10;
        MoveFlag = false;
        stageSelect = GameObject.Find("StageSelect");

        transform.position = savePos;
    }

    // Update is called once per frame
    void Update()
    {
        // �t�F�[�h���͏������Ȃ�
        if (FadeManager.alpha != 0.0f && FadeManager.alpha != 1.0f) return;

        // �|�W�V�����ۑ�
        savePos = transform.position;

        // ���j���[�t���O�������Ă����珈�����Ȃ�
        if (MenuManager.menuFlag) return;

        // ���肵�Ă��珈�����Ȃ�
        if (StageSelect.decideFlag) return;


       // �E�֑J��
       if (Input.GetKeyDown(KeyCode.RightArrow) && !MoveFlag &&
       (StageSelect.StageNum == 6 || StageSelect.StageNum == 11 || StageSelect.StageNum == 16 || StageSelect.StageNum == 21 ||
        StageSelect.StageNum == 26 || StageSelect.StageNum == 31 || StageSelect.StageNum == 36||StageSelect.StageNum == 41))
        {
            // ���W�����[�i0,0,0�j�̎��������Ȃ�
            if (StageSelect.StageNum == 0) return;

            //�ړ����ł͂Ȃ��ꍇ�͎��s 
            if (!MoveFlag)
            {
                MoveFlag = true;
                StartCoroutine("RightMove");
            }
        }
        // ���֑J��
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !MoveFlag &&
           (StageSelect.StageNum == 5 || StageSelect.StageNum == 10 || StageSelect.StageNum == 15 || StageSelect.StageNum == 20||
            StageSelect.StageNum == 25|| StageSelect.StageNum == 30|| StageSelect.StageNum == 35 || StageSelect.StageNum == 40 ||
            StageSelect.StageNum == 45))
        {
            // ���W���E�[�̎��������Ȃ�
            if (StageSelect.StageNum == StageSelect.MaxNum) return;


            //�ړ����ł͂Ȃ��ꍇ�͎��s 
            if (!MoveFlag)
            {
                MoveFlag = true;
                StartCoroutine("LeftMove");
            }
        }

        // 5�ړ��E
        if (Input.GetKeyDown(KeyCode.UpArrow) && !MoveFlag)
        {
            if(savePos.x > -160)
            {
                MoveFlag = true;
                StartCoroutine("RightMove");
            }
        }
        // 5�ړ���
        if (Input.GetKeyDown(KeyCode.DownArrow) && !MoveFlag)
        {
            if (savePos.x < 0)
            {
                MoveFlag = true;
                StartCoroutine("LeftMove");
            }
        }

        // �N�����v����
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -160, 0), 0, 0);

    }
    IEnumerator RightMove()
    {
        for (int turn = 0; turn < MoveX; turn++)
        {
            transform.Translate(-2, 0, 0);

            savePos.x -= 2;

            //�@�R���[�`���ĊJ����
            yield return new WaitForSeconds(0.01f);
        }
        MoveFlag = false;
    }

    //���ɂ�������]����90���ŃX�g�b�v
    IEnumerator LeftMove()
    {
        for (int turn = 0; turn < MoveX; turn++)
        {
            transform.Translate(2, 0, 0);

            savePos.x += 2;

            //�@�R���[�`���ĊJ����
            yield return new WaitForSeconds(0.01f);
        }
        MoveFlag = false;
    }
}