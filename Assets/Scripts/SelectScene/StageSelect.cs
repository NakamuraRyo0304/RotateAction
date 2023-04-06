using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    // �C���X�^���X����
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
        // brief:�E�L�[�������Ɓ{/���L�[�������Ɓ[�@��) 3-1�E�L�[�@3-2�@/�@2-1���L�[�@1-5�@/�@2-5�E�L�[�@3-1

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
