using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAlpha : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer leftArrow;
    [SerializeField]
    SpriteRenderer rightArrow;    
    [SerializeField]
    GameObject leftKey;
    [SerializeField]
    GameObject rightKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuManager.menuFlag) return;
        // フェード中は処理しない
        if (FadeManager.alpha != 0.0f && FadeManager.alpha != 1.0f) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //回転中ではない場合は実行 
            if (!Rotate.coroutineBool)
            {
                StartCoroutine("LeftAlpha");
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //回転中ではない場合は実行 
            if (!Rotate.coroutineBool)
            {
                StartCoroutine("RightAlpha");
            }
        }

        if (Goal.isGoalFlag)
        {
            MoveStage();
        }
    }

    IEnumerator LeftAlpha()
    {
        leftArrow.color = new Color(0f, 0f, 0f, 1f);

        //　コルーチン再開時間
        yield return new WaitForSeconds(1.5f);

        leftArrow.color = new Color(0f, 0f, 0f, 0.5f);
    }

    IEnumerator RightAlpha()
    {
        rightArrow.color = new Color(0f, 0f, 0f, 1f);

        //　コルーチン再開時間
        yield return new WaitForSeconds(1.5f);

        rightArrow.color = new Color(0f, 0f, 0f, 0.5f);
    }

    void MoveStage()
    {
        leftArrow.transform.position += new Vector3(0.0f, -0.2f, 0.0f);
        rightArrow.transform.position += new Vector3(0.0f, -0.2f, 0.0f);
        leftKey.transform.position += new Vector3(0.0f, -0.2f, 0.0f);
        rightKey.transform.position += new Vector3(0.0f, -0.2f, 0.0f);
    }
}
