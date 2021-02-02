using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameQuit : MonoBehaviour {

    public void GameQuitClick() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
            Application.OpenURL("http://www.yahoo.co.jp/");
        #else
            Application.Quit();
        #endif
    }

}