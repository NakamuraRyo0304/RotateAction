using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static int menuNum;
    Vector2[] playerPos = new Vector2[4];
    [SerializeField]
    GameObject menu;

    int menuNumAnim;

    [SerializeField]
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        menuNum = 1;
        menuNumAnim = 0;
        playerPos[0] = new Vector2(0f, 1.86f);
        playerPos[1] = new Vector2(0f, 0.72f);
        playerPos[2] = new Vector2(0f, -0.2f);
        playerPos[3] = new Vector2(0f, -1.81f);
    }

    // Update is called once per frame
    void Update()
    {
        menuNumAnim = animator.GetInteger("menuNum");

        menuNum = Mathf.Clamp(menuNum, 1, 4);
        menuNumAnim = Mathf.Clamp(menuNum, 1, 4);

        this.transform.position = playerPos[menuNum -1];

        if(Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            menuNum--;
            menuNumAnim--;
        }        
        if(Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            menuNum++;
            menuNumAnim++;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (menuNum == 3)
            {
                SceneManager.LoadScene("SelectScene");
                MenuManager.menuFlag = false;
                menu.SetActive(false);
            }
            if (menuNum == 4)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif            
            }

            menuNum = 1;
        }

        animator.SetInteger("menuNum", menuNumAnim);
    }
}

