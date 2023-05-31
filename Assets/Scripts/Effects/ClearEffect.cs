using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearEffect : MonoBehaviour
{
    [SerializeField]
    GameObject clearEffectL;
    [SerializeField]
    GameObject clearEffectR;

    bool prevFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Goal.isGoalFlag && !prevFlag)
        {
            Instantiate(clearEffectL);
            Instantiate(clearEffectR);

            StartCoroutine("EffectFalse");
            prevFlag = true;
        }
    }
}
