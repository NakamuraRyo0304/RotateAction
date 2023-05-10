using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnimator : MonoBehaviour
{
    [SerializeField]
    GameObject animatorObj;

    Animator checkAnim;

    void Start()
    {
        checkAnim = animatorObj.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if(checkAnim == null)
        {
            Debug.Log("not find");

        }

        if (checkAnim.GetBool("Close"))
        {
            Destroy(animatorObj);
        }
    }
}
