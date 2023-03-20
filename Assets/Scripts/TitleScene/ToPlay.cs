using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPlay : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            Change();
        }
    }
    void Change()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
