using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ΏۃI�u�W�F�N�g�̐U�����Ǘ�����N���X
public class CameraShake : MonoBehaviour
{
    [SerializeField] [Header("�p������")] float Duration;
    [SerializeField] [Header("�h��̑傫��")] float Magnitude;

    bool pushFlag;
    private void Start()
    {
        pushFlag = false;
    }
    private void Update()
    {
        if (MenuManager.menuFlag) return; 

        if((((Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.DownArrow)) && StageSelect.StageNum == 1)||
            ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)) && StageSelect.StageNum == 45))&&
            pushFlag == false)
        {
            //�@�������͉����Ȃ�����(����)
            pushFlag = true;

            //�@�R���[�`���̌Ăяo��
            StartCoroutine(Shake(Duration, Magnitude));
        }
       }
    //�@���ԂƗh�ꕝ
    IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.position;
        float elapsed = 0f;

        //�@�ݒ肵�����ԓ���������h�炷
        while (elapsed < duration)
        {
            //�@�����_���ō��W��ύX��������
            transform.position = originalPosition + Random.insideUnitSphere * magnitude;
            elapsed += Time.deltaTime;

            //�@���ԓ��͔����o���Ȃ�
            yield return null;
        }
        //�@�����ʒu�ɖ߂�
        transform.position = originalPosition;

        //�@�������͉����Ȃ�����(����)
        pushFlag = false;
    }
}
