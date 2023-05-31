using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpaceWave : MonoBehaviour
{
    void Update()
    {
        float sin = Mathf.Sin(Time.time * 2);
        this.transform.position = new Vector3(0, sin * 0.25f - 3.5f, 0);
    }
}
