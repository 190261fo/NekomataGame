using System;
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
    public   NekomataController neko;
    public Animator animator;
    public Animator animatorQuit;
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
        if (animator.GetBool("IsOpen") || animatorQuit.GetBool("IsOpen"))
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
        PlayerPrefs.SetInt("nekoMove", 1);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("nekoMove"));
    }

    private void Resume()
    {
        AudioManager.GetInstance().PlaySound(3);
        MenuUI.SetActive(false);
        IsMenu = false;
        PlayerPrefs.SetInt("nekoMove", 2);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("nekoMove"));
    }

    public void setMenuUIActive(Boolean x)
    {
        MenuUI.SetActive(x);
    }




}
