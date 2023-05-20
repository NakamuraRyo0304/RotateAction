using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotCount : MonoBehaviour
{
    private int rotCounter;
    void Start()
    {
        rotCounter = 0;
        DontDestroyOnLoad(this);
    }

    
    void Update()
    {
        // �t�F�[�h���͑���s�\�ɂ���
        if (FadeManager.alpha != 0.0f && FadeManager.alpha != 1.0f) return;

        // ���j���[���J���Ă����珈�����Ȃ�
        if (MenuManager.menuFlag) return;

        // �v���C�V�[���ȊO�͏������Ȃ�
        if (SceneManager.GetActiveScene().name != "Playscene") return;

        // �S�[�������珈�����Ȃ�
        if (Goal.isGoalFlag) return;

        // ����ł����珈�����Ȃ�
        if (PlayerController.deadFlag == true) return;

        // ��]�������Z����
        rotCounter += 1 * Rotate.rotFlagNum;
        Debug.Log("��]���F" + rotCounter);

        // �^�C�g���ŃJ�E���^���Z�b�g
        if(SceneManager.GetActiveScene().name == "TitleScene")
        {
            rotCounter = 0;
        }
    }

    public int GetCounter()
    {
        return rotCounter;
    }
}
