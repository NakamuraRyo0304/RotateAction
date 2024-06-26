using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseBlock : MonoBehaviour
{
    [SerializeField]
    GameObject BlockCol;
    [SerializeField]
    GameObject effect;

    public int timer;
    public float velocity;
    bool hitFlag;
    bool LRFlag;

    Vector2 scale = new Vector2(1.0f, 1.0f);
    Vector2 pos = new Vector2(0.0f, 0.0f);
    

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        velocity = 0.0f;
        hitFlag = false;
        LRFlag = true;
    }

    // Update is called once per frame
    void Update()
    {

        // ヒットフラグがtrueではないとき処理を抜ける
        if (!hitFlag)
            return;

        // 当ったらポジションの保存
        pos = this.transform.position;

        // タイマーの加算
        timer++;

        if (timer >= 120)
        {
            effect.SetActive(true);

            if (LRFlag)
            {
                velocity += 0.01f;

                if (velocity >= 0.02f)
                {
                    LRFlag = false;
                }

            }
            else if (!LRFlag)
            {
                velocity += -0.01f;
                if (velocity <= -0.02f)
                {
                    LRFlag = true;
                }

            }

            Vector2 pos1 = new Vector2(0.0f,0.0f);

            pos.x += velocity;
            this.transform.position = pos;
        }

        if (timer >= 240)
        {

            if (scale.x >= 0.5)
            {
                scale.x -= 0.01f;
                scale.y -= 0.01f;
                this.transform.localScale = scale;
            }
            if (timer >= 300)
            {
                Destroy(gameObject);
                Destroy(BlockCol);
                hitFlag = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitFlag = true;
    }
}




