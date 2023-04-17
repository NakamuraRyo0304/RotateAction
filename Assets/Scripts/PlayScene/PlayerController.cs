using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] GameObject fallEffect;
    [SerializeField] GameObject deadEffect;
    int effectTimer;
    bool effectflag = false;
    public static bool deadFlag;
    public Vector2 rotBeforPos = new(0, 0);
    public Vector2 rotAfterPos;
    public float posDistance;


    Vector2 deadPos = new(100, 0);

    private bool rotFlag;
   
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        deadFlag = false;
        rotFlag = false;
    }

    void Update()
    {
        if (!Rotate.instance.coroutineBool)
        {
            rotFlag = false;

            //　初期化
            transform.Rotate(Vector3.zero);
            transform.parent = null;
        }
        else
        {
            //　回転
            RotCtrl();

            transform.parent = GameObject.FindGameObjectWithTag("Stage").transform;
        }

        //　エフェクトの管理
        if(effectflag == true)
        {
            GetDistance();

            if (posDistance <= 30.0f)
            {
            Debug.Log("きちゃ");

                fallEffect.SetActive(true);
            }
            effectTimer += 1;

        }

        if (effectTimer >= 2)
        {
            rotBeforPos = rotAfterPos;
            fallEffect.SetActive(false);
            effectTimer = 0;
            effectflag = false;
        }

        if(deadFlag == true)
        {
            DeadController();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Block")
        {
            fallEffect.SetActive(true);
        }

        // 針に当たったらプレイヤーを消す
        if (collision.transform.tag == "Spline")
        {
            deadFlag = true;

        }

        // エフェクト
        if (collision.transform.tag == "Block")
        {
            effectflag = true; 
        }

    }

    void DeadController()
    {
        // 死亡エフェクト
        Instantiate(deadEffect, transform.position, Quaternion.identity);
        transform.position = deadPos;
        StartCoroutine("ReTry");

    }

    void GetDistance()
    {
        rotAfterPos = this.transform.position;

        if(rotBeforPos.y < 1)
        {
            rotBeforPos.y *= -1;
        }
        if (rotAfterPos.y < 1)
        {
            rotAfterPos.y *= -1;
        }

        posDistance = rotBeforPos.y + rotAfterPos.y;
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

    IEnumerator ReTry()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("PlayScene");
    }

}

