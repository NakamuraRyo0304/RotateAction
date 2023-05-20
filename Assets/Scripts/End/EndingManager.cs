using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    [SerializeField]
    Sprite[] nums;

    public bool one_Flag = false;
    public bool ten_Flag = false;
    public bool han_Flag = false;

    int number;
                         

    void Start()
    {
        // 数値の取得
        number = GameObject.FindGameObjectWithTag("RotateCounter").GetComponent<RotCount>().GetCounter();
    }

    // Update is called once per frame
    void Update()
    {
        if(one_Flag)
        {
            SetNum(number % 10);
        }

    }

    void SetNum(int num)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = nums[num];
    }

}
