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

       // effectPosition = player.transform.position;
        effectPosition = SpawnPosition[StageSelect.StageNum - 1].transform.position;
        Instantiate(spownEffect, effectPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {


        StartCoroutine("PlayerActiv");
    }

    IEnumerator PlayerActiv()
    {
        yield return new WaitForSeconds(0.9f);
        player.SetActive(true);
        playerFlag = true;
    }
}
