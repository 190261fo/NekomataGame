using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MainManager : MonoBehaviour 
{

    public Button BtnBack;
    public Button BtnNext;
    public Animator menu_Ani, game_Ani;
    public Timer timer;
    public GameManager gameManager;
    public static float AudioManagerVolume;
    // Start is called before the first frame update
    void Start()
    {
        AudioManagerVolume = AudioManager.GetInstance().BGMVolume;
        gameManager.MainS.volume = AudioManagerVolume;
        gameManager.SoundWIN.volume = AudioManagerVolume;
        gameManager.GameS.volume = AudioManagerVolume;
        timer.timecountdown.volume = AudioManagerVolume;
        AudioManager.GetInstance().BGM_Stop();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Next()
    {
        gameManager.Start();
        menu_Ani.SetBool("IsOpen", false);
        game_Ani.SetBool("IsOpen", true);
    }

    public void Back()
    { 

        game_Ani.SetBool("IsOpen", false);
        menu_Ani.SetBool("IsOpen", true);
        
    }


    public float getAudioManagerVolume()
    {
        return AudioManagerVolume;
        
    }

    


}
