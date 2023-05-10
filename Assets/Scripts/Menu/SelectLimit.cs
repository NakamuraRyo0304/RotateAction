using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLimit : MonoBehaviour
{
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sr.color = new Color(1.0f, 1.00f, 1.00f, 1f);

        if (SceneManager.GetActiveScene().name != "SelectScene") { return; }

          sr.color = new Color(0.27f, 0.27f, 0.27f, 1f);
    }
}
