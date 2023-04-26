using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObje: MonoBehaviour
{
    [SerializeField] [Header("”{—¦")] double rate;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -0.5f * (float)rate));
    }
}
