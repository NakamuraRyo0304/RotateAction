using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoPlay : MonoBehaviour
{
    void GoPlay ()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
