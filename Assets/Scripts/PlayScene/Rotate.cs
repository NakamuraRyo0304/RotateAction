using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public static Rotate instance;
    public bool coroutineBool;
    [SerializeField]
    float rotSpeed = 0.001f;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        coroutineBool = false;
    }

    private void Start()
    {
        coroutineBool = false;
    }

    private void Update()
    {
        if (MenuManager.menuFlag) return;
        //�@�v���C���[������ł��Ȃ��Ƃ����v���C���[���A�N�e�B�u�̂Ƃ��ɉ�]����
        if (PlayerController.deadFlag == false && SpownEffectControl.playerFlag == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                //��]���ł͂Ȃ��ꍇ�͎��s 
                if (!coroutineBool)
                {
                    coroutineBool = true;
                    StartCoroutine("RightRot");
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //��]���ł͂Ȃ��ꍇ�͎��s 
                if (!coroutineBool)
                {
                    coroutineBool = true;
                    StartCoroutine("LeftRot");
                }
            }
        }
        
    }

    //�E�ɂ�������]����90���ŃX�g�b�v
    IEnumerator RightRot()
    {
        //for (int turn = 0; turn < 90; turn++)
        //{
        //    transform.Rotate(0, 0, 1);
        //    //�@�R���[�`���ĊJ����
        //    yield return new WaitForSeconds(0.001f);
        //}
        for (int turn = 0; turn < 90; turn++)
        {
            transform.Rotate(0, 0, 1);
            //�@�R���[�`���ĊJ����
            yield return new WaitForSeconds(rotSpeed);
        }
        coroutineBool = false;
    }

    //���ɂ�������]����90���ŃX�g�b�v
    IEnumerator LeftRot()
    {

        //for (int turn = 0; turn < 90; turn++)
        //{
        //    transform.Rotate(0, 0, -1);
        //    //�@�R���[�`���ĊJ����
        //    yield return new WaitForSeconds(0.001f);
        //}
        for (int turn = 0; turn < 90; turn++)
        {
            transform.Rotate(0, 0, -1);
            //�@�R���[�`���ĊJ����
            yield return new WaitForSeconds(rotSpeed);
        }
        coroutineBool = false;

    }
}
