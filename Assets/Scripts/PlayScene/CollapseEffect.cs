using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseEffect : MonoBehaviour
{
    [SerializeField]
    GameObject block;

    public Vector3 rot;
    public Vector3 parent;
    // Start is called before the first frame update
    void Start()
    {
        rot = this.transform.localRotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        parent = block.transform.localRotation.eulerAngles;
        this.transform.localRotation = Quaternion.Euler(rot - parent);
    }
}
