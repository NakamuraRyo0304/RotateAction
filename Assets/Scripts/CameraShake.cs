using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 対象オブジェクトの振動を管理するクラス
public class CameraShake : MonoBehaviour
{
    int flag;
    Vector3 pos;

    private void Start()
    {
        flag = 0;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) && StageSelect.StageNum == 1||
            Input.GetKeyDown(KeyCode.RightArrow) && StageSelect.StageNum == 25)
        {
            if (flag == 0)
            {
                pos = transform.position;
                flag = 1;
            }
        }

        switch (flag)
        {
            case 1:
                goto case 3;

            case 3:
                transform.Translate(30 * Time.deltaTime, 0, 0);
                
                if (transform.position.x >= pos.x + 1.0f)
                    flag++;
                break;
            case 2:
                transform.Translate(-30 * Time.deltaTime, 0, 0);
                if (transform.position.x <= pos.x - 1.0f)
                    flag++;
                break;
            case 4:
                transform.Translate(-30 * Time.deltaTime, 0, 0);
                if (transform.position.x <= pos.x)
                {
                    gameObject.transform.position = pos;
                    flag = 0;
                }
                break;
        }
    }
}
