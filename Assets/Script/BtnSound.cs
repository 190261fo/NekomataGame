using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSound : MonoBehaviour {

    public void Click() {
        AudioManager.GetInstance().PlaySound(7);
    }
    
}
