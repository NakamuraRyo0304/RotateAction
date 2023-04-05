using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem fallEffect;
    [SerializeField]
    GameObject RootObject;

    public GameObject player;
    private Vector3 effectPosition;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.parent = RootObject.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        effectPosition = player.transform.position;
        Instantiate(fallEffect, effectPosition, Quaternion.identity);
    }
}
