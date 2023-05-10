using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField]
    GameObject warpObj;

    public static bool isWarpFlag;

    // Start is called before the first frame update
    void Start()
    {
        isWarpFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            isWarpFlag = true;
        }
        else
        {
            isWarpFlag = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.position = warpObj.transform.position;
        }
    }
}
