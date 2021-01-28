using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingBGM : MonoBehaviour {

   void Start() {
        AudioManager.GetInstance().PlayBGM(25);
    }

}
