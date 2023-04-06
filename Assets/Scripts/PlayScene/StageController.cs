using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    GameObject[] stage = new GameObject[0];
    [SerializeField]
    Vector3 stagePos = new Vector3(0,0,0);
    [SerializeField]
    int stageNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(stage[stageNum], stagePos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
