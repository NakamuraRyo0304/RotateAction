using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    int MoveX;
    bool MoveFlag;
    [SerializeField] [Header("エリア数")] int AreaNum;

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
            // 座標が右端の時処理しない
            if (transform.position.x == MoveX * (AreaNum - 1)) return;

            //移動中ではない場合は実行 
            if (!MoveFlag)
            {
                MoveFlag = true;
                StartCoroutine("RightMove");
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // 座標が左端（0,0,0）の時処理しない
            if (transform.position.x == 0) return;

            //移動中ではない場合は実行 
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
            //　コルーチン再開時間
            yield return new WaitForSeconds(0.01f);
        }
        MoveFlag = false;
    }

    //左にゆっくり回転して90°でストップ
    IEnumerator LeftMove()
    {
        for (int turn = 0; turn < MoveX; turn++)
        {
            transform.Translate(-1, 0, 0);
            //　コルーチン再開時間
            yield return new WaitForSeconds(0.01f);
        }
        MoveFlag = false;
    }

}
