using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllResetDatas : MonoBehaviour
{
    private void Awake()
    {
        // �T�E���h�̃��Z�b�g
        GameObject.Find("SE").gameObject.GetComponent<SoundManager>().ResetSound();

        // �X�e�[�W�Z���N�g�̃��Z�b�g
        StageSelect.StageNum = 1;

        // �X�e�[�W���[�u�̃��Z�b�g
        MoveStage.savePos = Vector3.zero;
    }

    void Start()
    {}

    void Update()
    {}
}
