using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFlame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(5.43f,-3.66f,0f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(1.07f,-3.66f,0f);
        }
    }
}
