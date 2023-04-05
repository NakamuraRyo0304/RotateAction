using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    int MoveX;
    bool MoveFlag;
    [SerializeField] [Header("�G���A��")] int AreaNum;

    void Start()
    {
        MoveX = 20;
        MoveFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // ���W���E�[�̎��������Ȃ�
            if (transform.position.x == MoveX * (AreaNum - 1)) return;

            //�ړ����ł͂Ȃ��ꍇ�͎��s 
            if (!MoveFlag)
            {
                MoveFlag = true;
                StartCoroutine("RightMove");
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
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
