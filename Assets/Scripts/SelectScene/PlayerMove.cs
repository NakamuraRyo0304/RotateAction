using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]GameObject[] PlayerStagePos;
    GameObject stageSelect;
    //StageSelect sl;
    void Start()
    {
        stageSelect = GameObject.Find("StageSelect");
        //sl = stageSelect.GetComponent<StageSelect>();
    }

    void Update()
    {
        switch (StageSelect.StageNum)
        {
            case 1:case 6:case 11:case 16:case 21:
                transform.position = PlayerStagePos[0].transform.position;
                break;
            case 2:case 7:case 12:case 17:case 22:
                transform.position = PlayerStagePos[1].transform.position;
                break;
            case 3:case 8:case 13:case 18:case 23:
                transform.position = PlayerStagePos[2].transform.position;
                break;
            case 4:case 9:case 14:case 19:case 24:
                transform.position = PlayerStagePos[3].transform.position;
                break;
            case 5:case 10:case 15:case 20:case 25:
                transform.position = PlayerStagePos[4].transform.position;
                break;

            default: break;
        }
    }
}
