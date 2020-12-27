using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenjiBGM : MonoBehaviour {

    void Start() {
        AudioManager.GetInstance().PlayBGM(5);
    }

    void Update() {

    }
}