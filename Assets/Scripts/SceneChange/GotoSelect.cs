using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour
{
    void GoSelect ()
    {
        SceneManager.LoadScene("SelectScene");
    }
}
