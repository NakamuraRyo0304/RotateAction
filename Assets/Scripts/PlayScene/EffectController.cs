using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem fallEffect;
    public GameObject player;
    private Vector3 effectPosition;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        effectPosition = player.transform.position;
        Instantiate(fallEffect, effectPosition, Quaternion.identity);
    }
}
