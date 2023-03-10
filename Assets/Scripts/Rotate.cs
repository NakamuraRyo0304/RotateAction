using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public static Rotate instance;
    public bool coroutineBool;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        coroutineBool = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //回転中ではない場合は実行 
            if (!coroutineBool)
            {
                coroutineBool = true;
                StartCoroutine("RightRot");
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //回転中ではない場合は実行 
            if (!coroutineBool)
            {
                coroutineBool = true;
                StartCoroutine("LeftRot");
            }
        }
    }

    //右にゆっくり回転して90°でストップ
    IEnumerator RightRot()
    {
        for (int turn = 0; turn < 90; turn++)
        {
            transform.Rotate(0, 0, 1);
            //　コルーチン再開時間
            yield return new WaitForSeconds(0.005f);
        }
        coroutineBool = false;
    }

    //左にゆっくり回転して90°でストップ
    IEnumerator LeftRot()
    {
        for (int turn = 0; turn < 90; turn++)
        {
            transform.Rotate(0, 0, -1);
            //　コルーチン再開時間
            yield return new WaitForSeconds(0.005f);
        }
        coroutineBool = false;
    }
}
