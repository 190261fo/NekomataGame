using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationQuitManager : MonoBehaviour
{
    public Animator animator;
    public MainManager mainManager;
    public Timer timer;
    public GameManager gameManager;
    // Start is called before the first frame update
    


    public void Open()
    {
        gameManager.GameS.Pause();
        timer.isPause = true;
        animator.SetBool("IsOpen", true);


        
    }

    public void Close()
    {
        animator.SetBool("IsOpen", false);


        if (gameManager.GameS.isPlaying == false)
        {
            gameManager.GameS.UnPause();
        }

        if (gameManager.Win == true)
        {
            timer.isPause = true;
        }
        else if (timer.isRunning == false)
        {
            timer.isPause = true;
        }
        else
        {
            timer.isPause = false;
        }


        if (timer.timeReady == false)
        {
            gameManager.animatorTextWinLose.SetBool("isOpen", false);
        }
    }

    public void BtnYes()
    {
        timer.isPause = true;
        timer.timecountdown.Stop();
        gameManager.MainS.Stop();
        animator.SetBool("IsOpen", false);
    }


    public void UnpauseMainS()
    {
        gameManager.MainS.UnPause();
    }
}
