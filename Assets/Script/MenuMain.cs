using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMain : MonoBehaviour
{
    public static Boolean IsMenu = false;
    public GameObject MenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (IsMenu)
            {
                Resume();
                
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        MenuUI.SetActive(true);
        IsMenu = true;
    }

    private void Resume()
    {
        MenuUI.SetActive(false);
        IsMenu = false;
    }

    public void setMenuUIActive(Boolean x)
    {
        MenuUI.SetActive(x);
    }

}
