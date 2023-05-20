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
    public AudioClip ending;

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

        // タイトルの曲
        if (SceneManager.GetActiveScene().name == "TitleScene" &&
            (First.clip == null || First.clip == ending))
        {
            First.Stop();
            First.clip = title;
            First.Play();
        }
        // プレイシーンの曲
        else if (SceneManager.GetActiveScene().name == "Playscene"&&
            First.clip == title)
        {
            First.Stop();
            First.clip = play;
            First.Play();
        }
        // エンディングの曲
        else if(SceneManager.GetActiveScene().name == "EndingScene" && 
            First.clip == play)
        {
            First.Stop();
            First.clip = ending;
            First.Play();
        }
    }

    void BGMVolume()
    {
        BGMSlider.volume = audioSource.volume;
    }
}
