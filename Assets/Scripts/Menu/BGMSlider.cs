using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMSlider : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(value => this.audioSource.volume = value);
    }

    // Update is called once per frame
    void Update()
    {

        if (MenuController.menuNum == 1)
        {
            if (!MenuManager.menuFlag) return;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //this.audioSource.volume -= 0.1f;
                slider.value -= 0.03f;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //this.audioSource.volume += 0.1f;
                slider.value += 0.03f;
            }
        }

    }
}
