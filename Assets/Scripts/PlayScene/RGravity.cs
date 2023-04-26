using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGravity : MonoBehaviour
{
    Vector3 pos = new Vector3 (0.0f, -0.3f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag =="Player")
        {
            transform.position += pos;
        }
    }
}
