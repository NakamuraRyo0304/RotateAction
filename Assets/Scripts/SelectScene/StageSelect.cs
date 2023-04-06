using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    // インスタンス生成
    public static StageSelect instance;

    public int StageNum;
    public int MaxNum = 25;

    GameObject Camera;
    MoveCamera mc;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()    
    {
        StageNum = 1;
        Camera = GameObject.Find("Main Camera");
        mc = Camera.GetComponent<MoveCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        // brief:右キーを押すと＋/左キーを押すとー　例) 3-1右キー　3-2　/　2-1左キー　1-5　/　2-5右キー　3-1

        if(Input.GetKeyDown(KeyCode.RightArrow) && !mc.MoveFlag)
        {
            if(StageNum < MaxNum)
            {
                StageNum++;
            }
            Debug.Log(StageNum);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && !mc.MoveFlag)
        {
            if(StageNum > 1)
            {
                StageNum--;
            }
            Debug.Log(StageNum);
        }
    }
}
