using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    public void click() {
        GetComponent<Button>().interactable = false;
    }
}
