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
   
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        JUMP_NUM = jumpNum;
    }

    void Update()
    {
        if (!Rotate.instance.coroutineBool)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(JUMP_NUM > 0)
                {
                    Vector2 force = new Vector2(0, jumpForce); 
                    rigidbody.AddForce(force);
                    JUMP_NUM--;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Block")
        {
            JUMP_NUM = jumpNum;


            //Å@âüÇµñﬂÇµ
            if (transform.position.x < collision.transform.position.x)
            {
                transform.Translate(new Vector2(transform.position.x - 0.1f, 0));
            }
            if (transform.position.x > collision.transform.position.x)
            {
                transform.Translate(new Vector2(transform.position.x + 0.1f, 0));
            }
            if (transform.position.y < collision.transform.position.y)
            {
                transform.Translate(new Vector2(0, transform.position.y - 0.1f));
            }
            if (transform.position.y > collision.transform.position.y)
            {
                transform.Translate(new Vector2(0, transform.position.y + 0.1f));
            }
        }
    }
}
