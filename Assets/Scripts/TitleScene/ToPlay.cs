using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPlay : MonoBehaviour
{
    private bool nextFlag;

    void Awake()
    {
        Application.targetFrameRate = 60; //60FPSÇ…ê›íË
    }

    void Start()
    {
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
            SceneManager.LoadScene("PlayScene");
        }
    }
}
