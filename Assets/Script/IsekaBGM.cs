using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsekaBGM : MonoBehaviour {

    void Start() {
        AudioManager.GetInstance().PlayBGM(6);
    }

    void Update() {

    }
}