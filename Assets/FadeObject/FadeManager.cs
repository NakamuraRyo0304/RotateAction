using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UI�̒ǉ�
using UnityEngine.UI;


public class FadeManager : MonoBehaviour
{
    // �t�F�[�h�I�u�W�F�N�g�𐶐�����t���O
    public static bool is_FadeInstance = false;

    // �t�F�[�h�C���̃t���O
    public bool is_FadeIn              = false;
    // �t�F�[�h�A�E�g�̃t���O
    public bool is_FadeOut             = false;

    // �����x(���ꂪ�ω����ăt�F�[�h�ɂȂ�)
    public float alpha                 = 0.0f;
    // �t�F�[�h�ɂ����鎞��
    public float fadeTime              = 0.0f;

    void Start()
    {
        // ��ԏ��߂ɋN���������쐬(�j��s�\�I�u�W�F�N�g�ɐݒ�)
        if (!is_FadeInstance)
        {
            is_FadeInstance = true;
        }
    }

    void Update()
    {
        // �t�F�[�h�C���̏���
        if(is_FadeIn)
        {
            // �t�F�[�h����
            alpha -= Time.deltaTime / fadeTime;
            alpha -= Time.deltaTime / fadeTime;
            
            // �����ɂȂ����珈���I��
            if(alpha <= 0.0f)
            {
                is_FadeIn = false;
                alpha = 0.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }

        // �t�F�[�h�A�E�g����
        else if(is_FadeOut)
        {
            // �t�F�[�h����
            alpha += Time.deltaTime / fadeTime;

            // �Ó]�����珈���I��
            if(alpha >= 1.0f)
            {
                is_FadeOut = false;
                alpha = 1.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
    }

    // �ȉ��A�Ăяo���p�֐�
    public void FadeIn()
    {
        is_FadeIn = true;
        is_FadeOut = false;
    }

    public void FadeOut()
    {
        is_FadeIn = false;
        is_FadeOut = true;
    }

    public float Alpha()
    {
        return alpha;
    }
}
