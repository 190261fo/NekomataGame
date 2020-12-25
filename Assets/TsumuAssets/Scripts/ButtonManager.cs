using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class ButtonManager : MonoBehaviour {

    public Flowchart flowchart;

    public void StartClick() {
        GetComponent<Button>().interactable = false;
    }

    public void RestartClick() {
        SceneManager.LoadScene("Tsumu");
    }
}
