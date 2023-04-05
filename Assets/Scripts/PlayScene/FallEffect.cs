using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallEffect : MonoBehaviour
{
    [SerializeField]
    float destoryTime = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destoryTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
