using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMusic : MonoBehaviour
{
    // �I�[�f�B�I�\�[�X
    [SerializeField] GameObject music;
    private AudioSource First;
    public AudioClip title;
    public AudioClip play;

    AudioSource audioSource;
    private void Start()
    {
        // �j��s�\�I�u�W�F�N�g�ɂ���
        DontDestroyOnLoad(this);

        // AudioSource���Q�b�g
        First = music.GetComponent<AudioSource>();

        // AudioClip�̐ݒ�
        First.clip = title;

        // AudioClip���Đ�
        First.Play();

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
    }
    private void Update()
    {
        BGMVolume();

        // �v���C�V�[���ɍs������폜����
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
