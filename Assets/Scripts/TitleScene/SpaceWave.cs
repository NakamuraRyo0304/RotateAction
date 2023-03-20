using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceWave : MonoBehaviour
{
    void Update()
    {
        float sin = Mathf.Sin(Time.time);
        this.transform.position = new Vector3(0, sin * 0.2f - 3, 0);
    }
}
