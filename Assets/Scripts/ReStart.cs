using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<DoorTextureChange>().ResetTexture();
    }

    // Update is called once per frame
    void Update()
    {
        if (AfterGoal.decideFlag) return;

        if(MenuManager.menuFlag) return;
        if(Goal.isGoalFlag)  return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Playscene");
        }
    }
}
