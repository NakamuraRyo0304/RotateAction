using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] int jumpForce;
    [SerializeField] int jumpNum;
    [SerializeField] GameObject warpPoint;
    [SerializeField] GameObject fallEffect;
    [SerializeField] int effectTimer;
    public 
    bool effectflag = false;

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

            //�@������
            transform.Rotate(Vector3.zero);
            transform.parent = null;
        }
        else
        {
            //�@��]
            RotCtrl();

            transform.parent = GameObject.FindGameObjectWithTag("Stage").transform;
        }

        if(effectflag == true)
        {
            fallEffect.SetActive(true);
            effectTimer += 1;
        }

        if (effectTimer == 2)
        {
            effectTimer = 0;
            fallEffect.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Block")
        {
            JUMP_NUM = jumpNum;
            fallEffect.SetActive(true);

        }

        if (collision.transform.tag == "Warp")
        {
            transform.position = warpPoint.transform.position;
        }


        //�G�t�F�N�g
        if (collision.transform.tag == "Block")
        {
            effectflag = true;
        }
    }


    void RotCtrl()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //��]���ł͂Ȃ��ꍇ�͎��s 
            if (!rotFlag)
            {
                rotFlag = true;
                StartCoroutine("LeftRot");
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //��]���ł͂Ȃ��ꍇ�͎��s 
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
            //�@�R���[�`���ĊJ����
            yield return new WaitForSeconds(0.005f);
        }
        rotFlag = false;
    }
    IEnumerator LeftRot()
    {
        for (int turn = 0; turn < 90; turn++)
        {
            transform.Rotate(0, 0, -1);
            //�@�R���[�`���ĊJ����
            yield return new WaitForSeconds(0.005f);
        }
        rotFlag = false;
    }
}

