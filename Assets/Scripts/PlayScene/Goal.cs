using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    // フェードオブジェクトを入れる
    //private GameObject fadeCanvas;

    // ゴール判定
    public static bool isGoalFlag = false;



    void Start()
    {
        isGoalFlag = false;
        //----------------------------------------------------------
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            isGoalFlag = true;
        }
    }

    // ！追記
    void Update()
    {

    }
}
