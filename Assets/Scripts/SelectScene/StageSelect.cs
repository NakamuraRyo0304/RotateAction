using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    int AreaNum;        // エリア番号        １～５
    int StageNum;       // ステージ番号      １～５
    void Start()    
    {
        AreaNum = 1;
        StageNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // brief:右キーを押すと＋/左キーを押すとー　例) 3-1右キー　3-2　/　2-1左キー　1-5　/　2-5右キー　3-1

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(StageNum < 5)
            {
                StageNum++;
            }
            else if(AreaNum < 5)
            {
                StageNum = 1;
                AreaNum++;
            }
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(StageNum > 1)
            {
                StageNum--;
            }
            else if(AreaNum > 1)
            {
                StageNum = 5;
                AreaNum--;
            }
        }
    }
}
