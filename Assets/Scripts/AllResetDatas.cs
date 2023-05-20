using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllResetDatas : MonoBehaviour
{
    private void Awake()
    {
        // サウンドのリセット
        GameObject.Find("SE").gameObject.GetComponent<SoundManager>().ResetSound();

        // ステージセレクトのリセット
        StageSelect.StageNum = 1;

        // ステージムーブのリセット
        MoveStage.savePos = Vector3.zero;
    }

    void Start()
    {}

    void Update()
    {}
}
