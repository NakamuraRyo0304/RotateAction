using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public static Rotate instance;
    public static bool coroutineBool;

    public static int rotFlagNum;

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
        rotFlagNum = 0;
    }

    private void Update()
    {
        // フェード中は操作不能に
        if (FadeManager.alpha != 0.0f && FadeManager.alpha != 1.0f) return;

        if (Goal.isGoalFlag)
        {
            MoveStage();
        }

        // メニューを開いていたら処理しない
        if (MenuManager.menuFlag) return;

        //　ゴールしたら処理しない
        if (Goal.isGoalFlag) return;

        rotFlagNum = 0;

        //　プレイヤーが死んでいないときかつプレイヤーがアクティブのときに回転する
        if (PlayerController.deadFlag == false && SpownEffectControl.playerFlag == true)
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
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //回転中ではない場合は実行 
                if (!coroutineBool)
                {
                    coroutineBool = true;
                    StartCoroutine("LeftRot");
                }
            }
        }
        
    }

    //右にゆっくり回転して90°でストップ
    IEnumerator RightRot()
    {
        for (int turn = 0; turn < 90; turn++)
        {
            transform.Rotate(0, 0, -1);
            //　コルーチン再開時間
            yield return new WaitForSeconds(rotSpeed);
        }
        coroutineBool = false;
        rotFlagNum = 1;
    }

    //左にゆっくり回転して90°でストップ
    IEnumerator LeftRot()
    {
        for (int turn = 0; turn < 90; turn++)
        {
            transform.Rotate(0, 0, 1);
            //　コルーチン再開時間
            yield return new WaitForSeconds(rotSpeed);
        }
        coroutineBool = false;
        rotFlagNum = 1;
    }

    void MoveStage()
    {
        transform.position += new Vector3(0.0f, -0.2f, 0.0f);

        if(transform.position.y < -200)
        {
            transform.position = new Vector3(0.0f, -200f);
        }
    }
}
