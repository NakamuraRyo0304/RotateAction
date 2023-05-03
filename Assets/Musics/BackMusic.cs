using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMusic : MonoBehaviour
{
    // オーディオソース
    [SerializeField] GameObject music;
    private AudioSource First;

    private void Start()
    {
        // 破壊不能オブジェクトにする
        DontDestroyOnLoad(this);

        // AudioSourceをゲット
        First = music.GetComponent<AudioSource>();

        // AudioClipを再生
        First.Play();

    }
    private void Update()
    {
        // プレイシーンに行ったら削除する
        if(SceneManager.GetActiveScene().name == "Playscene")
        {
            Destroy(this.gameObject);
        }
    }
}
