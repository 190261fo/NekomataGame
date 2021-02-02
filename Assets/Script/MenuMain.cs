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
    // Update is called once per frame
    void Update()
    {
        //Tsumu,RoratePuzzle,Tyouchin
        if (PlayerPrefs.GetInt("Tsumu")== 1)
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
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (IsMenu)
            {
                Resume();
                AudioManager.GetInstance().PlaySound(3);
            }
            else
            {
                Pause();
                AudioManager.GetInstance().PlaySound(4);
            }
        }
    }

    private  void Pause()
    {
        MenuUI.SetActive(true);
        IsMenu = true;
        PlayerPrefs.SetInt("nekoMove", 1);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("nekoMove"));
    }

    private void Resume()
    {
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
