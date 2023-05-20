using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ConManager : MonoBehaviour
{
    [SerializeField] Animator openAnim;

    // ���j���[���J���Ă��邩�̃t���O
    public static bool conFlag;

    // ���j���[���J�����Ƃ��ł��邩�ǂ����̃t���O
    public static bool Openmenu;
    // Openmenu�����ԂŊǗ����邽�߂̕ϐ�
    int timer;
    // ���j���[�ƃ��j���[�w�i���R���|�[�l���g
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject menuBack;

    public static bool concon;
    // Start is called before the first frame update
    void Start()
    {
        // �ϐ��̏�����
        conFlag = false;
        Openmenu = true;
    }

    // Update is called once per frame
    void Update()
    {
        // �V�[���J�ڒ��͑I��s�\�ɂ���
        if (FadeManager.alpha != 0 && FadeManager.alpha != 1)
        {
            conFlag = false;
            Openmenu = false;
            menuBack.SetActive(conFlag);
        }

        if (Openmenu)
        {
            if (MenuController.endFlag)
            {
                Debug.Log("������");

                // �t���O���]
                Openmenu = false;
                conFlag = !conFlag;
                concon = true;

                // �A�j���[�V�����J�n
                openAnim.enabled = true;

                // �A�j���[�V�����Ƀt���O���Z�b�g
                openAnim.SetBool("menuFlagAnim", conFlag);

                // ���j���[���A�N�e�B�u
                menuBack.SetActive(conFlag);

                MenuController.endFlag = false;
            }
            
        }

        //�@0.5�b�̃N�[���^�C��
        if (!Openmenu)
        {
            timer++;
        }
        if (timer > 30)
        {
            Openmenu = true;
            timer = 0;
        }
        else if (!conFlag)
        {
            Openmenu = true;

        }
    }
}
