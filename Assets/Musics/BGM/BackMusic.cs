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
    public AudioClip ending;

    AudioSource audioSource;

    static bool instance = false;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        if (!instance)
        {
           // �j��s�\�I�u�W�F�N�g�ɂ���
            DontDestroyOnLoad(this);
            instance = true;
        }
    }

    private void Start()
    {
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

        // �^�C�g���̋�/�Z���N�g�̋�
        if ((SceneManager.GetActiveScene().name == "TitleScene" ||
            SceneManager.GetActiveScene().name == "SelectScene")&&
            (First.clip == null || First.clip == ending || First.clip == play))
        {
            First.Stop();
            First.clip = title;
            First.Play();
        }
        // �v���C�V�[���̋�
        else if (SceneManager.GetActiveScene().name == "Playscene"&&
            First.clip == title)
        {
            First.Stop();
            First.clip = play;
            First.Play();
        }
        // �G���f�B���O�̋�
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
