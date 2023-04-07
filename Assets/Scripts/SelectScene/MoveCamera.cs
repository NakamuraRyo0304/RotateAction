using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // インスタンス生成
    public static MoveCamera instance;

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
        // 右へ遷移
        if (Input.GetKeyDown(KeyCode.RightArrow) &&
            (StageSelect.StageNum == 6 || StageSelect.StageNum == 11 || StageSelect.StageNum == 16 || StageSelect.StageNum == 21))
        {
            // 座標が右端の時処理しない
            if (transform.position.x == MoveX * StageSelect.MaxNum) return;

            //移動中ではない場合は実行 
            if (!MoveFlag)
            {
                MoveFlag = true;
                StartCoroutine("RightMove");
            }
        }
        // 左へ遷移
        if (Input.GetKeyDown(KeyCode.LeftArrow) &&
           (StageSelect.StageNum == 5 || StageSelect.StageNum == 10 || StageSelect.StageNum == 15 || StageSelect.StageNum == 20))
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