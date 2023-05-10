using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStage : MonoBehaviour
{
    // インスタンス生成
    public static MoveStage instance;

    int MoveX;
    public static bool MoveFlag;
    GameObject stageSelect;

    static Vector3 savePos = Vector3.zero;

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

        transform.position = savePos;

    }

    // Update is called once per frame
    void Update()
    {
        // ポジション保存
        savePos = transform.position;

        // メニューフラグがたっていたら処理しない
        if (MenuManager.menuFlag) return;

        // 決定してたら処理しない
        if (StageSelect.decideFlag) return;


            // 右へ遷移
       if (Input.GetKeyDown(KeyCode.RightArrow) &&
       (StageSelect.StageNum == 6 || StageSelect.StageNum == 11 || StageSelect.StageNum == 16 || StageSelect.StageNum == 21 ||
        StageSelect.StageNum == 26 || StageSelect.StageNum == 31 || StageSelect.StageNum == 36||StageSelect.StageNum == 41))
        {
            // 座標が左端（0,0,0）の時処理しない
            if (StageSelect.StageNum == 0) return;

            //移動中ではない場合は実行 
            if (!MoveFlag)
            {
                MoveFlag = true;
                StartCoroutine("RightMove");
            }
        }
        // 左へ遷移
        if (Input.GetKeyDown(KeyCode.LeftArrow) &&
           (StageSelect.StageNum == 5 || StageSelect.StageNum == 10 || StageSelect.StageNum == 15 || StageSelect.StageNum == 20||
            StageSelect.StageNum == 25|| StageSelect.StageNum == 30|| StageSelect.StageNum == 35 || StageSelect.StageNum == 40 ||
            StageSelect.StageNum == 45))
        {
            // 座標が右端の時処理しない
            if (StageSelect.StageNum == StageSelect.MaxNum) return;


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
            transform.Translate(-1, 0, 0);

            savePos.x -= turn;

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
            transform.Translate(1, 0, 0);

            savePos.x += turn;

            //　コルーチン再開時間
            yield return new WaitForSeconds(0.01f);
        }
        MoveFlag = false;
    }
}