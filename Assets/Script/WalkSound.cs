using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour {


    public void PlayWalkSound() {
        AudioManager.GetInstance().PlaySound(0);
    }

}
