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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //��]���ł͂Ȃ��ꍇ�͎��s 
            if (!Rotate.instance.coroutineBool)
            {
                StartCoroutine("LeftAlpha");
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //��]���ł͂Ȃ��ꍇ�͎��s 
            if (!Rotate.instance.coroutineBool)
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

        //�@�R���[�`���ĊJ����
        yield return new WaitForSeconds(1);

        leftArrow.color = new Color(0f, 0f, 0f, 0.5f);
    }

    IEnumerator RightAlpha()
    {
        rightArrow.color = new Color(0f, 0f, 0f, 1f);

        //�@�R���[�`���ĊJ����
        yield return new WaitForSeconds(1);

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