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
    public Animator animatorDataShowLoad;
    public Animator animatorDataShowLoad_Load;
    public Animator animatorDataShow_Save;
    public Animator animatorDataShow_Delete;

    public InputField inputField;
    public Text textTimeSave;
    public GameObject Youryoku_kappa;
    public GameObject Youryoku_tengu;
    public GameObject Youryoku_zashiki;
    public DataUI dataUI;
    public DataUI_Load dataUI_load;



    // Start is called before the first frame update

    public void DataShow(Boolean Is)
    {
        if (Is)
        {
            dataUI.fill_Data();
        }
        
        animatorDataShow.SetBool("IsOpen", Is);

    }


    public void DataShowLoad(Boolean Is)
    {
        if (Is)
        {
            dataUI_load.fill_Data();
        }

        animatorDataShow.SetBool("IsOpen", Is);

    }

    public void DataShowLoad_Load(Boolean Is)
    {
        

        animatorDataShowLoad_Load.SetBool("IsOpen", Is);

    }

    public void DataShowLoad_Load_BtnYes()
    {

        dataManager.Save(3, "");
        DataShowLoad_Load(false);

    }

    public void DataShowDelete(Boolean Is)
    {

        animatorDataShow_Delete.SetBool("IsOpen", Is);

    }

    public void DataShowSave(Boolean Is)
    {

        animatorDataShow_Save.SetBool("IsOpen", Is);

    }

    public void DataShowSave_BtnYes()
    {

        dataManager.Save(3,"");
        DataShowSave(false);
        
        dataUI.fill_Data();

    }

    public void DataShowDelete_BtnYes()
    {

        dataManager.Delete("one");
        DataShowDelete(false);
        //dataUI.setDelete();
        dataUI.delete_onetransform();
        
    }

    

    public void DataMini(Boolean Is)
    {
        if (Is)
        {
            textTimeSave.text = DateTime.Now.ToString();
            if(dataUI.CheckEdit == 1)
            {
                inputField.text = dataManager.DataGame[dataUI.IndexDataChange].DataName;
            }
            else
            {
                inputField.text = "";
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
            
        }
        animatorDataMini.SetBool("IsOpen", Is);
        
    }

    



    public void DataMini_BtnYes()
    {
        if(dataUI.CheckEdit == 1)
        {
            dataManager.Save(2, inputField.text);
            Debug.Log("check text:" + inputField.text);
            dataUI.CheckEdit = 0;
        }
        else
        {
            
            dataManager.SaveGame();
            if (dataUI.CheckDelete == 0)
            {
                dataUI.add_transform();
            }
            else
            {
                dataUI.CheckDelete = 0;
            }
            
            dataManager.Save(1, inputField.text);
        }
        DataMini(false);
        DataShow(true);


    }
    public void DataMini_BtnNo()
    {
        dataUI.CheckEdit = 0;
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
   
}
