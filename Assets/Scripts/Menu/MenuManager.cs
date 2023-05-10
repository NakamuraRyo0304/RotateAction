using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Animator openAnim;
    [SerializeField] Animator menuExp;

    // ���j���[���J���Ă��邩�̃t���O
    public static bool menuFlag;

    // ���j���[���J�����Ƃ��ł��邩�ǂ����̃t���O
    public static bool Openmenu;
    // Openmenu�����ԂŊǗ����邽�߂̕ϐ�
    int timer;
    // ���j���[�ƃ��j���[�w�i���R���|�[�l���g
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject menuBack;

    // Start is called before the first frame update
    void Start()
    {
        // �ϐ��̏�����
        menuFlag = false;
        Openmenu = true;
        // �V�[���ԂŃI�u�W�F�N�g��j�󂵂Ȃ�
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Openmenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // �t���O���]
                Openmenu = false;
                menuFlag = !menuFlag;

                // �A�j���[�V�����J�n
                openAnim.enabled = true;
                menuExp.enabled = true;

                // �A�j���[�V�����Ƀt���O���Z�b�g
                menuExp.SetBool("menuFlagAnim", menuFlag);
                openAnim.SetBool("menuFlagAnim", menuFlag);

                // ���j���[���A�N�e�B�u
                menuBack.SetActive(menuFlag);

                // ���j���[�őI�΂�Ă���Ƃ�������Z�b�g
                MenuController.menuNum = 1;
            }
        }

        //�@0.5�b�̃N�[���^�C��
        if(!Openmenu) 
        {
            timer++;
        }
        if (timer  > 30)
        {
            Openmenu = true;
            timer = 0;
        }
        else if (!menuFlag)
        {
            Openmenu = true;

        }
    }
}