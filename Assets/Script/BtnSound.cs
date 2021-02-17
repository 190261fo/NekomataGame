using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSound : MonoBehaviour {

    public void Click() {
        AudioManager.GetInstance().PlaySound(7);
    }

    public void Save_Click() {
        AudioManager.GetInstance().PlaySound(8);
    }

    public void Load_Click() {
        AudioManager.GetInstance().PlaySound(9);
    }
    
    public void Cancel_Click() {
        AudioManager.GetInstance().PlaySound(15);
    }

    public void PointerEnter_Btn() {
        AudioManager.GetInstance().PlaySound(16);
    }

}
