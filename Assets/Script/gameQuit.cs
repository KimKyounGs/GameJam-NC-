using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameQuit : MonoBehaviour
{
    public void GameExit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
