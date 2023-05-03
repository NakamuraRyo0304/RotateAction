using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static bool menuFlag;
    [SerializeField]
    GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        menuFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            menuFlag = !menuFlag;
            menu.SetActive(menuFlag);
        }
    }
}
