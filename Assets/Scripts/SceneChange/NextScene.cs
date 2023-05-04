using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    Scene scene;
    int buildIndex;
    private void Start()
    {
        // ���݂̃V�[�����擾
        scene = SceneManager.GetActiveScene();
	    // ���݂̃V�[���̃r���h�ԍ����擾
	    buildIndex = scene.buildIndex;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {  
            // ���݂̃V�[���̃r���h�ԍ����{�P�i���̃V�[���̃r���h�ԍ��ɂȂ�j
            buildIndex = buildIndex + 1;
            // �擾�����r���h�ԍ��̃V�[���i���݂̃V�[���j��ǂݍ���
            SceneManager.LoadScene(buildIndex);
        }
	}
}
