using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStage : MonoBehaviour
{
    // �C���X�^���X����
    public static MoveStage instance;

    int MoveX;
    public bool MoveFlag;
    GameObject stageSelect;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        MoveX = 20;
        MoveFlag = false;
        stageSelect = GameObject.Find("StageSelect");
    }

    // Update is called once per frame
    void Update()
    {
        // ���j���[�t���O�������Ă����珈�����Ȃ�
        if (MenuManager.menuFlag) return;

        // ���肵�Ă��珈�����Ȃ�
        if (StageSelect.decideFlag) return;

        // �E�֑J��
        if (Input.GetKeyDown(KeyCode.RightArrow) &&
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
        if (Input.GetKeyDown(KeyCode.LeftArrow) &&
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
    }
    IEnumerator RightMove()
    {
        for (int turn = 0; turn < MoveX; turn++)
        {
            transform.Translate(-1, 0, 0);
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
            transform.Translate(1, 0, 0);
            //�@�R���[�`���ĊJ����
            yield return new WaitForSeconds(0.01f);
        }
        MoveFlag = false;
    }
}