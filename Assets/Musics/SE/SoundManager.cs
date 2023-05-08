using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        // AudioSourceをゲット
        se = music.GetComponent<AudioSource>();

        // 一回だけ鳴らす
        keyFlag = false;
        splineFlag = false;

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        //  死亡音
        if(PlayerController.deadFlag)
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
        if(Warp.isWarpFlag)
        {
            se.clip = WarpSound;

            se.PlayOneShot(se.clip);
        }

        // ゴール音
        if(Goal.isGoalFlag)
        {
            se.clip = GoalSound;

            se.PlayOneShot(se.clip);

            // ゴールしたらリセット
            keyFlag = false;
            splineFlag = false;
        }

        // 重力音
        if(RGravity.isReverseGravityFlag)
        {
            se.clip = RgravitySound;

            se.PlayOneShot(se.clip);
        }

        // 鍵入手音
        if(PlayerController.keyFlag)
        {
            // なってなければ早期リターン
            if (keyFlag) return;

            se.clip = KeySound;

            se.PlayOneShot(se.clip);

            keyFlag = true;
        }

        // 鍵開閉音
        if(PlayerController.openFlag)
        {
            se.clip = KeyBlockSound;

            se.PlayOneShot(se.clip);
        }
    }
}
