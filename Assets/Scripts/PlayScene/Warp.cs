using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject warpObj;
    Vector2 warpPos;

    // Start is called before the first frame update
    void Start()
    {
        warpPos = warpObj.transform.position;
        //warpPos.y += 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            player.transform.position = warpPos;
    }
}
