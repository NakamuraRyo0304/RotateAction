using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 MoveStagePos;

    [SerializeField]GameObject[] PlayerStagePos;
    void Start()
    {
        MoveStagePos = new Vector3(0.0f,100.0f,0.0f);
    }

    void Update()
    {
        // フェード中は処理しない
        if (FadeManager.alpha != 0.0f && FadeManager.alpha != 1.0f) return;

        // メニューフラグがたっていたら処理しない
        if (MenuManager.menuFlag) return;

        // 決定してたら動かさない
        if (StageSelect.decideFlag) return;
        
        switch (StageSelect.StageNum)
        {
            case 1:
            case 6:
            case 11:
            case 16:
            case 21:
            case 26:
            case 31:
            case 36:
            case 41:

                transform.position = PlayerStagePos[0].transform.position;

                break;
            case 2:
            case 7:
            case 12:
            case 17:
            case 22:
            case 27:
            case 32:
            case 37:
            case 42:

                transform.position = PlayerStagePos[1].transform.position;

                break;
            case 3:
            case 8:
            case 13:
            case 18:
            case 23:
            case 28:
            case 33:
            case 38:
            case 43:

                transform.position = PlayerStagePos[2].transform.position;

                break;
            case 4:
            case 9:
            case 14:
            case 19:
            case 24:
            case 29:
            case 34:
            case 39:
            case 44:

                transform.position = PlayerStagePos[3].transform.position;

                break;
            case 5:
            case 10:
            case 15:
            case 20:
            case 25:
            case 30:
            case 35:
            case 40:
            case 45:

                transform.position = PlayerStagePos[4].transform.position;

                break;



            default: 
                break;
        }

        if(MoveStage.MoveFlag)
        {
            transform.position = MoveStagePos;
        }

    }
}
