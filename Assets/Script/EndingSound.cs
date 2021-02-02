using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSound : MonoBehaviour {

    public void CatSound1() {
        AudioManager.GetInstance().PlaySound(17);
    }
    public void CatSound2() {
        AudioManager.GetInstance().PlaySound(18);
    }

    public void CatSound3() {
        AudioManager.GetInstance().PlaySound(19);
    }
    
}
