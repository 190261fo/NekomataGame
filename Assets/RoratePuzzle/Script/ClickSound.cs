using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour {

    public void click() {
        AudioManager.GetInstance().PlaySound(30);
    }
    
}
