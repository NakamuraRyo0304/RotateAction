using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoSelect : MonoBehaviour
{
    void GoSelect ()
    {
        SceneManager.LoadScene("SelectScene");
    }
}
