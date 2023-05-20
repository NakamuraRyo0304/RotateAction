using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    // �C���X�^���X����
    public static StageSelect instance;

    public static int StageNum = 1;
    public static int MaxNum = 45;

    public static bool decideFlag;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()    
    {
        decideFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �t�F�[�h���͏������Ȃ�
        if (FadeManager.alpha != 0.0f && FadeManager.alpha != 1.0f) return;

        // ���j���[�t���O�������Ă����珈�����Ȃ�
        if (MenuManager.menuFlag) return;

        // ����t���O�������Ă��珈�����Ȃ�
        if (decideFlag) return;

        if (MoveStage.MoveFlag) return;

        // brief:�E�L�[�������Ɓ{/���L�[�������Ɓ[�@��) 3-1�E�L�[�@3-2�@/�@2-1���L�[�@1-5�@/�@2-5�E�L�[�@3-1

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(StageNum < MaxNum)
            {
                StageNum++;
            }
            Debug.Log(StageNum);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(StageNum > 1)
            {
                StageNum--;
            }
            Debug.Log(StageNum);
        }

        // �G���A�ړ�
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(StageNum < MaxNum)
            {
                StageNum += 5;
                Debug.Log(StageNum);
            }
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(StageNum > 5)
            {
                StageNum -= 5;
                Debug.Log(StageNum);
            }
        }

        // �N�����v����
        StageNum = Mathf.Clamp(StageNum, 1, MaxNum);

        // ���肷��
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            decideFlag = true;
        }
    }
}
