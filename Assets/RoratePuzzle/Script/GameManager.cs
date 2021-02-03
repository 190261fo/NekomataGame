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
    public AudioClip winS;
    public AudioClip loseS;
    public AudioSource GameS;
    public AudioSource MainS;

    public Fade fade;

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
        MainS.Pause();
        GameS.PlayOneShot(winS);
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

        // ↓ 勝利したら"ゲームをやめるかどうか"を尋ねずに、画面遷移したい
        // notificationQuitManager.Open();

        // ↓簡易の画面遷移関数
        if (PlayerPrefs.GetInt("MiniGameMode3") == 1)
        {
           

        }
        else
        {
            Invoke("Isekai", 3.0f);
        }
    }

    //↓簡易の画面遷移関数
    void Isekai()
	{
		// フェードイン
		fade.FadeIn(1.3f, () =>
		{
			// フェードイン完了後の処理（画面は真っ暗）
			SceneManager.LoadScene("IsekaiScene"); //　シーン遷移
		});
	}

    public void setLose()
    {
        //AudioManager.GetInstance().PlaySound(35);
        timer.timecountdown.Stop();
        MainS.Pause();
        GameS.PlayOneShot(loseS);
        timer.timeReady = true;
        TextWin_lose.text = "...敗北!";
        TextWin_lose.color = new Color32(162, 11, 0, 255);
        animatorTextWinLose.SetBool("isOpen", true);
        蛇パズル_背景.GetComponent<SpriteRenderer>().color = new Color32(82, 56, 27, 255);
        
        if (PlayerPrefs.GetInt("MiniGameMode3") == 1)
        {

        }
        else
        {
            notificationQuitManager.Open();
        }
    }


    public void Replay()
    {
        MainS.UnPause();  
        MainS.volume = mainManager.getAudioManagerVolume()/3;
        Start();
        GameS.Stop();
    }

    public void Back()
    {
        GameS.Pause();
        timer.isPause = true;
        notificationBackManager.Open();
    }

    public void　StartGame()
    {
        MainS.volume = mainManager.getAudioManagerVolume() / 4;
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
