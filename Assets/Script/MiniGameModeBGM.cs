using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameModeBGM : MonoBehaviour {
    void Start() {
        AudioManager.GetInstance().PlayBGM(3);
    }
}
