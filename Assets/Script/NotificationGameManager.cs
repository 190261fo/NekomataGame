using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class NotificationGameManager : MonoBehaviour
{
    public DataManager dataManager;
    public Animator animatorDataMini;
    public Animator animatorQuit;
    public Animator animatorDataShow;
    public InputField inputField;
    public Text textTimeSave;
    public GameObject Youryoku_kappa;
    public GameObject Youryoku_tengu;
    public GameObject Youryoku_zashiki;

    public Data data;

    // Start is called before the first frame update

    public void DataShow(Boolean Is)
    {
        if (Is)
        {
            data.ShowData();
        }
        
        animatorDataShow.SetBool("IsOpen", Is);

    }

    public void DataMini(Boolean Is)
    {
        if (Is)
        {
            textTimeSave.text = DateTime.Now.ToString();
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
        }
        animatorDataMini.SetBool("IsOpen", Is);
        
    }

  

    public void DataMini_BtnYes()
    {
        DataMini(false);
        dataManager.SaveGame();
        dataManager.Save(inputField.text);
        
    }
    public void DataMini_BtnNo()
    {
        DataMini(false);
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
