using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    // �I�[�f�B�I�\�[�X
    [SerializeField] GameObject music;
    private AudioSource se;
    [Header("�v���C�V�[��")]
    [SerializeField] AudioClip GoalSound;
    [SerializeField] AudioClip WarpSound;
    [SerializeField] AudioClip SprineSound;
    [SerializeField] AudioClip RgravitySound;
    [SerializeField] AudioClip KeySound;
    [SerializeField] AudioClip KeyBlockSound;
    [Header("�Z���N�g�V�[��")]
    [SerializeField] AudioClip SelectSound;
    [Header("���j���[�J����Esc")]
    [SerializeField] AudioClip OpenMenuSound;
    [Header("���j���[���鉹Esc")]
    [SerializeField] AudioClip CloseMenuSound;

    [Header("�N���b�N���iSpace�j")]
    [SerializeField] AudioClip PushSpaceSound;

    private bool keyFlag;
    private bool splineFlag;
    private bool goalFlag;

    MenuManager menuManager;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        // AudioSource���Q�b�g
        se = music.GetComponent<AudioSource>();

        // ��񂾂��炷
        keyFlag = false;
        splineFlag = false;
        goalFlag = false;

        // ���j���[�}�l�[�W���[���Q�b�g
        menuManager  = GetComponent<MenuManager>();

    }

    private void Update()
    {
        // �펞�Ȃ���(Menu)
        if(Input.GetKeyDown(KeyCode.Escape) && MenuManager.Openmenu)
        {
            se.Stop();

            if(!MenuManager.menuFlag)
                se.clip = OpenMenuSound;
            else
                se.clip = CloseMenuSound;

            se.PlayOneShot(se.clip);
        }

        // �Z���N�g�V�[���̏���
        if (SceneManager.GetActiveScene().name == "SelectScene" && !MenuManager.menuFlag)
        {        
            // �Z���N�g�V�[���̃T�E���h(�X�e�[�W�I����)
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // �Z���N�g��
                se.clip = SelectSound;

                se.PlayOneShot(se.clip);
            }
        }
        

        // �v���C�V�[������Ȃ���΃��^�[��
        if (SceneManager.GetActiveScene().name != "Playscene")
        {
            keyFlag = false;
            splineFlag = false;
            goalFlag = false;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                // ���艹
                se.clip = PushSpaceSound;

                se.PlayOneShot(se.clip);
            }

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
