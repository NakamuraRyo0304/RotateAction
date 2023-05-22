using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackEffect : MonoBehaviour
{
    static bool instance = false;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        if(!instance)
        {
            DontDestroyOnLoad(gameObject);
            instance = true;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
