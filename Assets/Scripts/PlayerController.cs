using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] int moveSpeed;
    [SerializeField] int jumpForce;
    [SerializeField] int jumpNum;

    int JUMP_NUM;

    private bool rotFlag;
   
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        JUMP_NUM = jumpNum;
        rotFlag = false;
    }

    void Update()
    {
        if (!Rotate.instance.coroutineBool)
        {
            //　移動
            MoveCtrl();

            rotFlag = false;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(JUMP_NUM > 0)
                {
                    Vector2 force = new Vector2(0, jumpForce); 
                    rigidbody.AddForce(force);
                    JUMP_NUM--;
                }
            }

            //　初期化
            transform.Rotate(Vector3.zero);
            transform.parent = null;
        }
        else
        {
            //　回転
            RotCtrl();

            transform.parent = GameObject.Find("StageFlame").transform;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Block")
        {
            JUMP_NUM = jumpNum;
        }
    }

    void MoveCtrl()
    { 
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));
        }
    }

    void RotCtrl()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //回転中ではない場合は実行 
            if (!rotFlag)
            {
                rotFlag = true;
                StartCoroutine("LeftRot");
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //回転中ではない場合は実行 
            if (!rotFlag)
            {
                rotFlag = true;
                StartCoroutine("RightRot");
            }
        }
    }
    IEnumerator RightRot()
    {
        for (int turn = 0; turn < 90; turn++)
        {
            transform.Rotate(0, 0, 1);
            //　コルーチン再開時間
            yield return new WaitForSeconds(0.005f);
        }
        rotFlag = false;
    }
    IEnumerator LeftRot()
    {
        for (int turn = 0; turn < 90; turn++)
        {
            transform.Rotate(0, 0, -1);
            //　コルーチン再開時間
            yield return new WaitForSeconds(0.005f);
        }
        rotFlag = false;
    }
}

