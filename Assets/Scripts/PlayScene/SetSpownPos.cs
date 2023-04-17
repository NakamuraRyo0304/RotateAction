using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpownPos : MonoBehaviour
{
    [SerializeField]
    GameObject[] SpawnPosition;
    void Start()
    {
        transform.position = SpawnPosition[StageSelect.StageNum - 1].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
