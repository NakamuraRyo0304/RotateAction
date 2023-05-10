using System.Collections;
using UnityEngine;

public class FallEffectController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem FallEffect;
    [SerializeField] GameObject player;
    private Vector3 effectPosition;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        effectPosition = player.transform.position;
        Instantiate(FallEffect, effectPosition, Quaternion.identity);
    }
}
