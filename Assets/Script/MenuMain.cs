﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMain : MonoBehaviour
{
    public static Boolean IsMenu = false;
    public GameObject MenuUI;
    public GameObject Youryoku_kappa;
    public GameObject Youryoku_tengu;
    public GameObject Youryoku_zashiki;
    public NekomataController neko;
    public Animator DataMini;
    public Animator Quit;
    public Animator DataShow;
    public Animator DataShowLoad;


    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Tsumu") == 1)
        {
            Youryoku_zashiki.SetActive(true);
        }
        if (PlayerPrefs.GetInt("RoratePuzzle") == 1)
        {
            Youryoku_tengu.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Tyouchin") == 1)
        {
            Youryoku_kappa.SetActive(true);
        }
        if (DataMini.GetBool("IsOpen") || Quit.GetBool("IsOpen")|| DataShow.GetBool("IsOpen") || DataShowLoad.GetBool("IsOpen"))
        {

        }
        else
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
        //Tsumu,RoratePuzzle,Tyouchin
        
       
    }

    private  void Pause()
    {
        AudioManager.GetInstance().PlaySound(4);
        MenuUI.SetActive(true);
        IsMenu = true;
        neko.Move(false);
    }

    private void Resume()
    {
        AudioManager.GetInstance().PlaySound(3);
        MenuUI.SetActive(false);
        IsMenu = false;
        neko.Move(true);
    }

    public void setMenuUIActive(Boolean x)
    {
        MenuUI.SetActive(x);
    }




}
