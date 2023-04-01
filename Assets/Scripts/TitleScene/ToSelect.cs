using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToSelect : MonoBehaviour
{
    [SerializeField] int max_Move;
    bool to_Select;
    int pos;
    void Start()
    {
        pos = 0;
        to_Select = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& to_Select == false)
        {
            to_Select = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && to_Select == true)
        {
            to_Select = false;
        }
        if(to_Select == true && transform.position.x < max_Move)
        {
            pos++;
            transform.Translate(new Vector3(1, 0, 0));
        }
        if (to_Select == false && transform.position.x > 0)
        {
            pos--;
            transform.Translate(new Vector3(-1, 0, 0));
        }
    }
}
