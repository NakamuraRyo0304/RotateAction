using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseEffect : MonoBehaviour
{
    [SerializeField]
    GameObject block;

    Vector3 rot = new Vector3 (0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        rot = transform.localRotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 parent = block.transform.localRotation.eulerAngles;
        transform.localRotation = Quaternion.Euler(rot - parent);
    }
}
