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

    private void Start()
    {
        // AudioSourceをゲット
        se = music.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Goal")
        {
            se.clip = GoalSound;
        }
        if(collision.transform.tag == "Warp")
        {
            se.clip = WarpSound;
        }
        if(collision.transform.tag == "Sprine")
        {
            se.clip = SprineSound;
        }
        if(collision.transform.tag == "RGravity")
        {
            se.clip = RgravitySound;
        }
        if(collision.transform.tag == "KeyBlock")
        {
            se.clip = KeyBlockSound;
        }
        if(collision.transform.tag == "Key")
        {
            se.clip = KeySound;
        }

        se.PlayOneShot(se.clip);
    }
}
