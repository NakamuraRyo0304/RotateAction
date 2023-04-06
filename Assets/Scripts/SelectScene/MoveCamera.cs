using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // �C���X�^���X����
    public static MoveCamera instance;

    int MoveX;
    public bool MoveFlag;
    GameObject StageSelect;
    StageSelect sl;

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
        StageSelect = GameObject.Find("StageSelect");
        sl = StageSelect.GetComponent<StageSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        // �E�֑J��
        if (Input.GetKeyDown(KeyCode.RightArrow) &&
            (sl.StageNum == 6 || sl.StageNum == 11 || sl.StageNum == 16 || sl.StageNum == 21))
        {
            // ���W���E�[�̎��������Ȃ�
            if (transform.position.x == MoveX * sl.MaxNum) return;

            //�ړ����ł͂Ȃ��ꍇ�͎��s 
            if (!MoveFlag)
            {
                MoveFlag = true;
                StartCoroutine("RightMove");
            }
        }
        // ���֑J��
        if (Input.GetKeyDown(KeyCode.LeftArrow) &&
           (sl.StageNum == 5 || sl.StageNum == 10 || sl.StageNum == 15 || sl.StageNum == 20))
        {
            // ���W�����[�i0,0,0�j�̎��������Ȃ�
            if (transform.position.x == 0) return;

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
            transform.Translate(1, 0, 0);
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
            transform.Translate(-1, 0, 0);
            //�@�R���[�`���ĊJ����
            yield return new WaitForSeconds(0.01f);
        }
        MoveFlag = false;
    }

}
