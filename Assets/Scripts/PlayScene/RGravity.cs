using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGravity : MonoBehaviour
{
    public static bool isReverseGravityFlag;

    // Start is called before the first frame update
    void Start()
    {
        isReverseGravityFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag =="Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale *= -1;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            isReverseGravityFlag = true;
        }
        else
        {
            isReverseGravityFlag = false;
        }
    }
}
