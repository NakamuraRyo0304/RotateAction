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
        // フェード中は操作不能に
        if (FadeManager.alpha != 0.0f && FadeManager.alpha != 1.0f) return;

        if (AfterGoal.decideFlag) return;

        if(MenuManager.menuFlag) return;
        if(Goal.isGoalFlag)  return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Playscene");
        }
    }
}
