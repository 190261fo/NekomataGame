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
    public Animator animatorDataShow_DeleteAll;
    public ChangeScene changeScene;
    public InputField inputField;
    public Text textTimeSave;
    public Text textNoDataShow;
    public Text textNoDataShowLoad;
    public Button Btn_DeleteAll;
    public GameObject Youryoku_kappa;
    public GameObject Youryoku_tengu;
    public GameObject Youryoku_zashiki;
    public GameObject Utsuwa_kappa;
    public GameObject Utsuwa_tengu;
    public GameObject Utsuwa_zashiki;
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

        animatorDataShowLoad.SetBool("IsOpen", Is);

    }

    public void DataShowLoad_Load(Boolean Is)
    {
        

        animatorDataShowLoad_Load.SetBool("IsOpen", Is);

    }

    public void DataShowLoad_Load_BtnYes()
    {

        dataManager.FillDataToGame();
        changeScene.ChangeMap(PlayerPrefs.GetString("Scene"));
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
        if (PlayerPrefs.GetInt("OutGame") == 1)
        {
            changeScene.ChangeTitle();
            
        }
        else
        {
            DataShowSave(false);

            dataUI.fill_Data();
        }

        PlayerPrefs.SetInt("OutGame", 0);
        PlayerPrefs.Save();


    }

    public void DataShowDelete_BtnYes()
    {

        dataManager.Delete("one");
        DataShowDelete(false);
        dataUI.delete_onetransform();
        
    }

    public void DataShowDeleteAll_BtnYes()
    {
        dataManager.Delete("All");
        DataShowDeleteAll(false);
        dataUI.delete_alltransform();
        dataUI.fill_transform();

    }

    public void DataShowDeleteAll(Boolean Is)
    {
        animatorDataShow_DeleteAll.SetBool("IsOpen", Is);
    }



    public void DataMini(Boolean Is)
    {
        Debug.Log("CheckEdit:" + dataUI.CheckEdit);
        if (Is)
        {
            textTimeSave.text = DateTime.Now.ToString();
            if(dataUI.CheckEdit == 1)
            {
                List<DataSave> l = dataManager.DataGame;
                int i = dataUI.IndexDataChange;
                Debug.Log("Nuber :" + i);
                inputField.text = l[i].DataName;
                if (l[i].TsutsuYR == 1)
                {
                    Utsuwa_zashiki.SetActive(false);
                    Youryoku_zashiki.SetActive(true);
                }
                else
                {
                    Utsuwa_zashiki.SetActive(true);
                    Youryoku_zashiki.SetActive(false);
                }
                if (l[i].HebiYR == 1)
                {
                    Utsuwa_tengu.SetActive(false);
                    Youryoku_tengu.SetActive(true);
                }
                else
                {
                    Utsuwa_tengu.SetActive(true);
                    Youryoku_tengu.SetActive(false);
                }
                if (l[i].TyochinYR == 1)
                {
                    Utsuwa_kappa.SetActive(false);
                    Youryoku_kappa.SetActive(true);
                }
                else
                {
                    Utsuwa_kappa.SetActive(true);
                    Youryoku_kappa.SetActive(false);
                }
            }
            else
            {
                inputField.text = "";
                if (PlayerPrefs.GetInt("Tsumu") == 1)
                {
                    Utsuwa_zashiki.SetActive(false);
                    Youryoku_zashiki.SetActive(true);
                }
                else
                {
                    Utsuwa_zashiki.SetActive(true);
                    Youryoku_zashiki.SetActive(false);
                }
                if (PlayerPrefs.GetInt("RoratePuzzle") == 1)
                {
                    Utsuwa_tengu.SetActive(false);
                    Youryoku_tengu.SetActive(true);
                }
                else
                {
                    Utsuwa_tengu.SetActive(true);
                    Youryoku_tengu.SetActive(false);
                }
                if (PlayerPrefs.GetInt("Tyouchin") == 1)
                {
                    Utsuwa_kappa.SetActive(false);
                    Youryoku_kappa.SetActive(true);
                }
                else
                {
                    Utsuwa_kappa.SetActive(true);
                    Youryoku_kappa.SetActive(false);
                }
            }
            
        }
        animatorDataMini.SetBool("IsOpen", Is);
        
    }

    



    public void DataMini_BtnYes()
    {
        
        if (PlayerPrefs.GetInt("OutGame") == 1)
        {
            if (dataUI.CheckDelete == 0)
            {
                dataUI.add_transform();
            }
            else
            {
                dataUI.CheckDelete = 0;
            }

            dataManager.Save(1, inputField.text);
            changeScene.ChangeTitle();

        }
        else
        {

            if (dataUI.CheckEdit == 1)
            {

                dataManager.Save(2, inputField.text);
                dataUI.CheckEdit = 0;
            }
            else
            {
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
        if (!Btn_DeleteAll.interactable)
        {

            textNoDataShow.gameObject.SetActive(false);
            textNoDataShowLoad.gameObject.SetActive(false);
            Btn_DeleteAll.interactable = true;
        }
        PlayerPrefs.SetInt("OutGame", 0);
        PlayerPrefs.Save();


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
        DataShow(true);
        PlayerPrefs.SetInt("OutGame", 1);
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
