using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] int moveSpeed;
    [SerializeField] int jumpForce;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 force = new Vector2(0, jumpForce);  //y²•ûŒü‚Ì‚İ”’l‚ğ‰Á‚¦‚é
            rigidbody.AddForce(force);  //ƒWƒƒƒ“ƒv
        }
    }
}
