using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStageForSelect : MonoBehaviour
{
    [SerializeField]GameObject[] Stage;
    void Start()
    {
    }

    void Update()
    {
        Stage[StageSelect.StageNum - 1].transform.Rotate(0, 0, 1);

        if(Input.GetKeyDown(KeyCode.RightArrow)||
            Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Stage[StageSelect.StageNum - 1].transform.rotation = Quaternion.identity;
        }

    }
}
