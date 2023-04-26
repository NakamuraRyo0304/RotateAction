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
    [SerializeField] GameObject key;
    int effectTimer;
    bool effectflag = false;
    public static bool deadFlag;
    bool keyFlag;
    public static bool openFlag;

    public Vector2 rotBeforPos = new(0, 0);
    public Vector2 rotAfterPos;
    public float posDistance;

    float gravityTemp;

    Vector2 deadPos = new(100, 0);

    private bool rotFlag;
   
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        deadFlag = false;
        rotFlag = false;
        keyFlag = false;
        openFlag = false;
    }

    void Update()
    {
        // ��]���o�Ȃ��Ƃ��̂݉�]�\
        if (!Rotate.instance.coroutineBool)
        {
            rotFlag = false;

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

        //�@�G�t�F�N�g�̊Ǘ�
        if(effectflag == true)
        {
            GetDistance();

            if (posDistance <= 30.0f)
            {

            }
            effectTimer += 1;

        }
        // ��莞�Ԍ�ɍ폜
        if (effectTimer >= 2)
        {
            rotBeforPos = rotAfterPos;
            fallEffect.SetActive(false);
            effectTimer = 0;
            effectflag = false;
        }

        // ���񂾂Ƃ��̔���
        if(deadFlag == true)
        {
            DeadController();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �G�t�F�N�g
        if (collision.transform.tag == "Block")
        {
            fallEffect.SetActive(true);
            effectflag = true; 
        }

        // �j�ɓ���������v���C���[������
        if (collision.transform.tag == "Spline")
        {
            deadFlag = true;
        }

        if (collision.transform.tag == "RGravity")
        {
            rigidbody.gravityScale = -1;
        }

        if ((collision.transform.tag == "Key"))
        {
            keyFlag = true;
            Destroy(key);
        }

        if ((collision.transform.tag == "KeyBlock"))
        {
            if (keyFlag == true)
            {
                openFlag = true;
            }
        }
    }

    void DeadController()
    {
        // ���S�G�t�F�N�g
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

    IEnumerator ReTry()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("PlayScene");
    }

}

