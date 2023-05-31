using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SESlider : MonoBehaviour
{
    public Slider slider;
    AudioSource audioSource;

    public static float volume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("SE").GetComponent<AudioSource>();

        slider.onValueChanged.AddListener(volume => this.audioSource.volume = volume);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = volume;

        if (SceneManager.GetActiveScene().name == ("Playscene"))
        {
            MenuController.menuNum = PlayMenu.menuNum;
        }

        if (MenuController.menuNum == 2 || PlayMenu.menuNum == 2)
        {
            if (!MenuManager.menuFlag) return;
            if (ConManager.conFlag) return;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                slider.value -= 0.03f;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                slider.value += 0.03f;
            }
        }

    }
}
