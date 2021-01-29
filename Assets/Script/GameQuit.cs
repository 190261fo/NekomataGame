using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameQuit : MonoBehaviour {

    public void GameQuitClick() {
        UnityEditor.EditorApplication.isPlaying = false;
        UnityEngine.Application.Quit();
    }

}
