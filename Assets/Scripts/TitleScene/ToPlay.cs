using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPlay : MonoBehaviour
{
    private bool nextFlag;
    private int count;
    void Start()
    {
        count = 0;
        nextFlag = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextFlag = true;
        }

        if(nextFlag)
        {
            count++;
            if (count > 120)
            {
                Change();
            }
        }
    }
    void Change()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
