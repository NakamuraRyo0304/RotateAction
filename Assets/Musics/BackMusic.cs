using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMusic : MonoBehaviour
{
    // �I�[�f�B�I�\�[�X
    [SerializeField] GameObject music;
    private AudioSource First;

    private void Start()
    {
        // �j��s�\�I�u�W�F�N�g�ɂ���
        DontDestroyOnLoad(this);

        // AudioSource���Q�b�g
        First = music.GetComponent<AudioSource>();

        // AudioClip���Đ�
        First.Play();

    }
    private void Update()
    {
        // �v���C�V�[���ɍs������폜����
        if(SceneManager.GetActiveScene().name == "Playscene")
        {
            Destroy(this.gameObject);
        }
    }
}
