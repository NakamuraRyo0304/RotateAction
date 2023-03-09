using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    bool coroutineBool;

    private void Start()
    {
        coroutineBool = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //��]���ł͂Ȃ��ꍇ�͎��s 
            if (!coroutineBool)
            {
                coroutineBool = true;
                StartCoroutine("RightMove");
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //��]���ł͂Ȃ��ꍇ�͎��s 
            if (!coroutineBool)
            {
                coroutineBool = true;
                StartCoroutine("LeftMove");
            }
        }
    }

    //�E�ɂ�������]����90���ŃX�g�b�v
    IEnumerator RightMove()
    {
        for (int turn = 0; turn < 90; turn++)
        {
            transform.Rotate(0, 0, 1);
            yield return new WaitForSeconds(0.005f);
        }
        coroutineBool = false;
    }

    //���ɂ�������]����90���ŃX�g�b�v
    IEnumerator LeftMove()
    {
        for (int turn = 0; turn < 90; turn++)
        {
            transform.Rotate(0, 0, -1);
            yield return new WaitForSeconds(0.005f);
        }
        coroutineBool = false;
    }
}
