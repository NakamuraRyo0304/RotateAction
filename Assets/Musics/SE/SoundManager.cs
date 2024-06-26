using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    // オーディオソース
    [SerializeField] GameObject music;
    private AudioSource se;
    [Header("セレクトシーン")]
    [Header("選択音")]
    [SerializeField] AudioClip SelectSound;
    [Header("メニュー開く音Esc")]
    [SerializeField] AudioClip OpenMenuSound;
    [Header("メニュー閉じる音Esc")]
    [SerializeField] AudioClip CloseMenuSound;
    [Header("クリック音（Space）")]
    [SerializeField] AudioClip PushSpaceSound;
    [Header("プレイシーン")]
    [Header("ゴールの音")]
    [SerializeField] AudioClip GoalSound;
    [Header("ワープした時の音")]
    [SerializeField] AudioClip WarpSound;
    [Header("死亡音（棘ブロック）")]
    [SerializeField] AudioClip SprineSound;
    [Header("重力アイテム獲得音")]
    [SerializeField] AudioClip RgravitySound;
    [Header("鍵開錠音")]
    [SerializeField] AudioClip KeyBlockSound;

    private bool keyFlag;
    private bool splineFlag;
    private bool goalFlag;

    AudioSource audioSource;

    static bool instance = false;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        if (!instance)
        {
            // 破壊不能オブジェクトにする
            DontDestroyOnLoad(this);
            instance = true;
        }
    }

    private void Start()
    {
        // AudioSourceをゲット
        se = music.GetComponent<AudioSource>();

        // 一回だけ鳴らす
        ResetSound();

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;

    }

    private void Update()
    {
        SEVolume();

        // フェード中処理しない
        if (FadeManager.alpha != 0.0f && FadeManager.alpha != 1.0f) return;

        // 常時なるやつ(Menu)
        if (Input.GetKeyDown(KeyCode.Escape) && MenuManager.Openmenu && !ConManager.conFlag)
        {
            // 開いてる時
            if (MenuManager.menuFlag)
            {
                se.clip = CloseMenuSound;
            }
            // 閉じてる時
            else
            {
                se.clip = OpenMenuSound;
            }
            se.PlayOneShot(se.clip);
        }


        // セレクトシーンの処理
        if ((SceneManager.GetActiveScene().name == "SelectScene" && !MenuManager.menuFlag)||
            SceneManager.GetActiveScene().name == "Playscene" && Goal.isGoalFlag ||
            (ConManager.conFlag && !ConManager.concon))
        {        
            // セレクトシーンのサウンド(ステージ選択音)
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // セレクト音
                se.clip = SelectSound;

                se.PlayOneShot(se.clip);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (SceneManager.GetActiveScene().name == "SelectScene" && !MenuManager.menuFlag)
                {                 
                    // セレクト音
                    se.clip = SelectSound;

                    se.PlayOneShot(se.clip);
                }
            }
        }

        // メニュー開いてる時
        if (MenuManager.menuFlag)
        {
            // セレクト時
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                // セレクト音
                se.clip = SelectSound;

                se.PlayOneShot(se.clip);
            }

            // スペース音
            if(Input.GetKeyDown(KeyCode.Space))
            {
                // 現在なっているSEを止める
                se.Stop();

                // 決定音
                se.clip = PushSpaceSound;

                se.PlayOneShot(se.clip);
            }
        }


        // プレイシーンじゃないとき、プレイシーンでゴールした時
        if (SceneManager.GetActiveScene().name != "Playscene" ||
           (SceneManager.GetActiveScene().name == "Playscene" && Goal.isGoalFlag))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // もしフェード中なら音を出さない
                if (FadeManager.alpha != 0.0f && FadeManager.alpha != 1.0f) return;

                // 現在なっているSEを止める
                se.Stop();

                // 決定音
                se.clip = PushSpaceSound;

                se.PlayOneShot(se.clip);
            }
        }

        // プレイシーン以外は鳴らさない
        if (SceneManager.GetActiveScene().name != "Playscene") return;

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
        if (PlayerController.warpFlag)
        {
            se.clip = WarpSound;

            se.PlayOneShot(se.clip);
        }

        // 重力音
        if (PlayerController.rgravityFlag)
        {
            se.clip = RgravitySound;

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

        // 鍵入手音
        if (PlayerController.keyFlag)
        {
            // なってなければ早期リターン
            if (keyFlag) return;

            se.clip = KeyBlockSound;

            se.PlayOneShot(se.clip);

            keyFlag = true;
        }
    }

    public void ResetSound()
    {
        keyFlag = false;
        splineFlag = false;
        goalFlag = false;
    }

    void SEVolume()
    {
        SESlider.volume = audioSource.volume;
    }
}
