using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windowsize : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Screen.SetResolution(1280, 800, false);
    }
}
