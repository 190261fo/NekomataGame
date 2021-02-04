using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationGameManager : MonoBehaviour
{
    public DataManager dataManager;
    public Animator animator;
    public Animator animatorQuit;
    // Start is called before the first frame update



    public void Open()
    {
        animator.SetBool("IsOpen", true);
    }

    public void Close()
    {
        animator.SetBool("IsOpen", false);

    }

    public void BtnYes()
    {
        Close();
        dataManager.SaveGame();
    }
    public void BtnNo()
    {
        Close();
    }

    public void QuitOpen()
    {
        animatorQuit.SetBool("IsOpen", true);
    }

    public void QuitClose()
    {
        animatorQuit.SetBool("IsOpen", false);

    }

    public void animationQuit_BtnYes()
    {
        QuitClose();
        dataManager.SaveGame();
    }
    public void animationQuit_BtnNo()
    {
        QuitClose();
    }

    public void animationQuit_BtnNoSave()
    {
        dataManager.DeleteData();
    }
    public void SetVoid()
    {
        Debug.Log("");
    }
}
