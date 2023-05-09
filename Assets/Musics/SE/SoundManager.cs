using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    // オーディオソース
    [SerializeField] GameObject music;
    private AudioSource se;
    [SerializeField] AudioClip GoalSound;
    [SerializeField] AudioClip WarpSound;
    [SerializeField] AudioClip SprineSound;
    [SerializeField] AudioClip RgravitySound;
    [SerializeField] AudioClip KeySound;
    [SerializeField] AudioClip KeyBlockSound;

    private bool keyFlag;
    private bool splineFlag;
    private bool goalFlag;

    private void Start()
    {
        // AudioSourceをゲット
        se = music.GetComponent<AudioSource>();

        // 一回だけ鳴らす
        keyFlag = false;
        splineFlag = false;
        goalFlag = false;

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // プレイシーンじゃなければリターン
        if (SceneManager.GetActiveScene().name != "Playscene")
        {
            keyFlag = false;
            splineFlag = false;
            goalFlag = false;

            // リセットが終わったらリターン
            return;
        }
        //  死亡音
        if (PlayerController.deadFlag)
        {
            // なってなければ早期リターン
            if (splineFlag) return;

            se.clip = SprineSound;

            se.PlayOneShot(se.clip);

            splineFlag = true;
        }
        else
        {
            splineFlag = false;
        }

        // ワープ音
        if (Warp.isWarpFlag)
        {
            se.clip = WarpSound;

            se.PlayOneShot(se.clip);
        }

        // ゴール音
        if (Goal.isGoalFlag)
        {
            if (goalFlag) return;

            se.clip = GoalSound;

            se.PlayOneShot(se.clip);

            goalFlag = true;
        }

        // 重力音
        if (RGravity.isReverseGravityFlag)
        {
            se.clip = RgravitySound;

            se.PlayOneShot(se.clip);
        }

        // 鍵入手音
        if (PlayerController.keyFlag)
        {
            // なってなければ早期リターン
            if (keyFlag) return;

            se.clip = KeySound;

            se.PlayOneShot(se.clip);

            keyFlag = true;
        }

        // 鍵開閉音
        if (PlayerController.openFlag)
        {
            se.clip = KeyBlockSound;

            se.PlayOneShot(se.clip);
        }
    }
}
