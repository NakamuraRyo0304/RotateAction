using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MenuManager.menuFlag) { return; }
        if(Goal.isGoalFlag) { return; }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Playscene");
        }
    }
}