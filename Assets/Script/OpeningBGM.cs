using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningBGM : MonoBehaviour {

    void Start() {
        AudioManager.GetInstance().PlayBGM(2);
    }

}
