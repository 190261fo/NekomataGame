using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public Timer timer;
    public MainManager mainManager;
    [SerializeField] int totalPic = 0;
    [SerializeField] int correctPic = 0;
    public Boolean Win;
    public Boolean FlagRorate;
    public GameObject 蛇パズル_背景;
    public PicScript[] picScripts;
    public GameObject[] a_k_s;
    public Animator animatorTextWinLose, animatorImageWIN;
    public Text TextWin_lose;
    public Button BtnStart, BtnReplay;

    public NotificationBackManager notificationBackManager;
    public NotificationQuitManager notificationQuitManager;
    public AudioClip winS1;
    public AudioClip loseS;
    public AudioClip winS2;
    public AudioSource GameS;
    public AudioSource MainS;
    public AudioSource SoundWIN;
    public void Start()
    {
        
        //AudioManager.GetInstance().PlayBGM(20);
        animatorImageWIN.SetBool("IsOpen", false);
        BtnStart.interactable = true;
        BtnReplay.interactable = false;
        PicNew();
        timer.TimeStart();
        Win = false;
        FlagRorate = false;
        totalPic = picScripts.Length;
        animatorTextWinLose.SetBool("isOpen", false);
        蛇パズル_背景.GetComponent<SpriteRenderer>().color = new Color32(205, 205, 205, 255);
        foreach (GameObject pic in a_k_s)
        {
            pic.GetComponent<SpriteRenderer>().color = new Color32(202,193, 193, 125);

        }
        foreach (PicScript pic in picScripts)
        {
            pic.GetComponent<SpriteRenderer>().color = new Color32(202,193, 193, 125);
        }
    }



    public void correctMove()
    {
        correctPic += 1;
        if (correctPic == totalPic)
        {
            Win = true;
        }
    }

    public void wrongMove()
    {
        correctPic -= 1;
    }

    public void PicNew()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        correctPic = 0;
        foreach (PicScript pic in picScripts)
        {
            pic.isPlaced = false;
            pic.New();   
        }
    }


    public void setWin()
    {
        //AudioManager.GetInstance().PlaySound(33);
        //AudioManager.GetInstance().PlaySound(34);
        PlayerPrefs.SetInt("RoratePuzzle", 1);
        PlayerPrefs.Save();
        MainS.volume = 0.02f;
        SoundWIN.PlayOneShot(winS2);
        GameS.PlayOneShot(winS1);
        timer.timecountdown.Stop();
        TextWin_lose.text = "...勝利!";
        TextWin_lose.color = new Color32(198, 129, 22, 255);
        animatorTextWinLose.SetBool("isOpen", true);
        蛇パズル_背景.GetComponent<SpriteRenderer>().color = new Color32(82, 56, 27, 255);
        foreach (GameObject pic in a_k_s)
        {
            pic.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);
        }
        foreach (PicScript pic in picScripts)
        {
            pic.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);
        }
        animatorImageWIN.SetBool("IsOpen", true);

        notificationQuitManager.Open();

    }

    public void setLose()
    {
        //AudioManager.GetInstance().PlaySound(35);
        MainS.volume = 0.02f;
        GameS.PlayOneShot(loseS);
        timer.timeReady = true;
        TextWin_lose.text = "...敗北!";
        TextWin_lose.color = new Color32(162, 11, 0, 255);
        animatorTextWinLose.SetBool("isOpen", true);
        蛇パズル_背景.GetComponent<SpriteRenderer>().color = new Color32(82, 56, 27, 255);
        notificationQuitManager.Open();
    }


    public void Replay()
    {
        MainS.volume = mainManager.getAudioManagerVolume();
        Start();
        GameS.Stop();
        SoundWIN.Stop();
    }

    public void Back()
    {
        GameS.Pause();
        SoundWIN.Pause();
        timer.isPause = true;
        notificationBackManager.Open();
    }

    public void　StartGame()
    {
        MainS.volume = 0.02f;
        timer.timeReady = false;
        timer.isPause = false;
        FlagRorate = true;
        timer.isRunning = true;
        BtnStart.interactable = false;
        BtnReplay.interactable = true;
        foreach (PicScript pic in picScripts)
        {
            pic.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255 , 255);
        }
    }


    
}
