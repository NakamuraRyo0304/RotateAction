using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    Scene scene;
    int buildIndex;
    private void Start()
    {
        // 現在のシーンを取得
        scene = SceneManager.GetActiveScene();
	    // 現在のシーンのビルド番号を取得
	    buildIndex = scene.buildIndex;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {  
            // 現在のシーンのビルド番号を＋１（次のシーンのビルド番号になる）
            buildIndex = buildIndex + 1;
            // 取得したビルド番号のシーン（現在のシーン）を読み込む
            SceneManager.LoadScene(buildIndex);
        }
	}
}
