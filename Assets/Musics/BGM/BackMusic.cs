using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMusic : MonoBehaviour
{
    // オーディオソース
    [SerializeField] GameObject music;
    private AudioSource First;
    public AudioClip title;
    public AudioClip play;

    AudioSource audioSource;
    private void Start()
    {
        // 破壊不能オブジェクトにする
        DontDestroyOnLoad(this);

        // AudioSourceをゲット
        First = music.GetComponent<AudioSource>();

        // AudioClipの設定
        First.clip = title;

        // AudioClipを再生
        First.Play();

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
    }
    private void Update()
    {
        BGMVolume();

        // プレイシーンに行ったら削除する
        if (SceneManager.GetActiveScene().name == "Playscene"&&
            First.clip == title)
        {
            First.Stop();
            First.clip = play;
            First.Play();
        }
        else if(SceneManager.GetActiveScene().name != "Playscene" &&
            First.clip == play)
        {
            First.Stop();
            First.clip = title;
            First.Play();
        }
    }

    void BGMVolume()
    {
        BGMSlider.volume = audioSource.volume;
    }
}
