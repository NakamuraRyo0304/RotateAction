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

    }
    private void Update()
    {
        // �v���C�V�[���ɍs������폜����
        if(SceneManager.GetActiveScene().name == "Playscene"&&
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
}
