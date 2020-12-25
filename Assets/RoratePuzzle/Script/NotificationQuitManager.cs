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
        animator.SetBool("IsOpen", true);
    }

    public void Close()
    {
        animator.SetBool("IsOpen", false);

    }

    public void BtnYes()
    {
        Close();
    }
}
