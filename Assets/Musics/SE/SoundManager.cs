using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    // �I�[�f�B�I�\�[�X
    [SerializeField] GameObject music;
    private AudioSource se;
    [SerializeField] AudioClip GoalSound;
    [SerializeField] AudioClip WarpSound;
    [SerializeField] AudioClip SprineSound;
    [SerializeField] AudioClip RgravitySound;
    [SerializeField] AudioClip KeySound;
    [SerializeField] AudioClip KeyBlockSound;

    private bool keyFlag;
    private bool splineFlag;
    private bool goalFlag;

    private void Start()
    {
        // AudioSource���Q�b�g
        se = music.GetComponent<AudioSource>();

        // ��񂾂��炷
        keyFlag = false;
        splineFlag = false;
        goalFlag = false;

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // �v���C�V�[������Ȃ���΃��^�[��
        if (SceneManager.GetActiveScene().name != "Playscene")
        {
            keyFlag = false;
            splineFlag = false;
            goalFlag = false;

            // ���Z�b�g���I������烊�^�[��
            return;
        }
        //  ���S��
        if (PlayerController.deadFlag)
        {
            // �Ȃ��ĂȂ���Α������^�[��
            if (splineFlag) return;

            se.clip = SprineSound;

            se.PlayOneShot(se.clip);

            splineFlag = true;
        }
        else
        {
            splineFlag = false;
        }

        // ���[�v��
        if (Warp.isWarpFlag)
        {
            se.clip = WarpSound;

            se.PlayOneShot(se.clip);
        }

        // �S�[����
        if (Goal.isGoalFlag)
        {
            if (goalFlag) return;

            se.clip = GoalSound;

            se.PlayOneShot(se.clip);

            goalFlag = true;
        }

        // �d�͉�
        if (RGravity.isReverseGravityFlag)
        {
            se.clip = RgravitySound;

            se.PlayOneShot(se.clip);
        }

        // �����艹
        if (PlayerController.keyFlag)
        {
            // �Ȃ��ĂȂ���Α������^�[��
            if (keyFlag) return;

            se.clip = KeySound;

            se.PlayOneShot(se.clip);

            keyFlag = true;
        }

        // ���J��
        if (PlayerController.openFlag)
        {
            se.clip = KeyBlockSound;

            se.PlayOneShot(se.clip);
        }
    }
}
