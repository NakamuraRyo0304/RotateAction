using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 対象オブジェクトの振動を管理するクラス
public class CameraShake : MonoBehaviour
{
    [SerializeField] [Header("継続時間")] float Duration;
    [SerializeField] [Header("揺れの大きさ")] float Magnitude;

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
            //　処理中は押せなくする(制限)
            pushFlag = true;

            //　コルーチンの呼び出し
            StartCoroutine(Shake(Duration, Magnitude));
        }
       }
    //　時間と揺れ幅
    IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.position;
        float elapsed = 0f;

        //　設定した時間内だったら揺らす
        while (elapsed < duration)
        {
            //　ランダムで座標を変更し続ける
            transform.position = originalPosition + Random.insideUnitSphere * magnitude;
            elapsed += Time.deltaTime;

            //　時間内は抜け出さない
            yield return null;
        }
        //　初期位置に戻す
        transform.position = originalPosition;

        //　処理中は押せなくする(解除)
        pushFlag = false;
    }
}
