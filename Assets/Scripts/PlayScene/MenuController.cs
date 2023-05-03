using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public int menuNum;
    Vector2[] playerPos = new Vector2[4];

    // Start is called before the first frame update
    void Start()
    {
        menuNum = 1;
        playerPos[0] = new Vector2(0.0f, 2.37f);
        playerPos[1] = new Vector2(0.0f, 1.06f);
        playerPos[2] = new Vector2(0.0f, -0.21f);
        playerPos[3] = new Vector2(0.0f, -1.7f);
    }

    // Update is called once per frame
    void Update()
    {
        menuNum = Mathf.Clamp(menuNum, 1, 4);

        this.transform.position = playerPos[menuNum -1];

        if(Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            menuNum--;
        }        
        if(Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            menuNum++;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (menuNum == 1)
            {
            }
            if (menuNum == 2)
            {
            }
            if (menuNum == 3)
            {
                SceneManager.LoadScene("SelectScene");
            }
            if (menuNum == 4)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif            
            }
        }
    }
}
