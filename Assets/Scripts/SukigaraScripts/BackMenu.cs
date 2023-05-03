using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMenu : MonoBehaviour
{
    bool selectFlag;
    // Start is called before the first frame update
    void Start()
    {
        selectFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectFlag = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectFlag = true;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(selectFlag)
            {
                SceneManager.LoadScene("SelectScene");
            }
            else
            {
                SceneManager.LoadScene("PlayScene");
            }
        }

    }
}
