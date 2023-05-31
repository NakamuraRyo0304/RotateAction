using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownEffectControl : MonoBehaviour
{
    [SerializeField]
    ParticleSystem spownEffect;
    [SerializeField] GameObject player;
    private Vector3 effectPosition;
    public static bool playerFlag;

    [SerializeField]
    GameObject[] SpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerFlag = false;

        // 透明にする
        player.GetComponent<SpriteRenderer>().color = new Vector4(1,1,1,0);

        // 重力を０にする
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

    // effectPosition = player.transform.position;
    effectPosition = SpawnPosition[StageSelect.StageNum - 1].transform.position;
        Instantiate(spownEffect, effectPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerFlag)
        {
            // スポーン地点を設定
            player.transform.position = effectPosition;
            // 速度をリセット
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }

        StartCoroutine("PlayerActiv");
       
    }

    IEnumerator PlayerActiv()
    {
        yield return new WaitForSeconds(0.7f);

        //player.SetActive(true);
        player.GetComponent<SpriteRenderer>().color = Color.white;

        playerFlag = true;
    }
}
