using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;







public class DataUI_Load : MonoBehaviour
{




    public DataManager dataManager;
    public NotificationGameManager notificationGameManager;
    
    


    private int indexDataChange = 0;
    public int IndexDataChange { get => indexDataChange; set => indexDataChange = value; }

    // Start is called before the first frame update
    void Start()
    {
        fill_transform();
        fill_Data();
    }

    public void fill_transform()
    {
        dataManager.LoadData();

        if (dataManager.DataGame.Count >= 1)
        {
            notificationGameManager.textNoDataShowLoad.gameObject.SetActive(false);
            transform.gameObject.SetActive(true);
            GameObject child = transform.GetChild(0).gameObject;

            for (int i = 0; i < dataManager.DataGame.Count; i++)
            {
                Instantiate(child, transform);
            }

            Destroy(child);
            Debug.Log("loadeeeee"+ transform.childCount);
        }
        else
        {
            notificationGameManager.textNoDataShowLoad.gameObject.SetActive(true);
            transform.gameObject.SetActive(false);
        }

    }



    public void fill_Data()
    {
            dataManager.LoadData();
        if (dataManager.DataGame.Count != 0)
        {
            transform.gameObject.SetActive(true);
            List<DataSave> dataGame = dataManager.DataGame;

            for (int i = 0; i < dataGame.Count; i++)
            {
                GameObject g = transform.GetChild(i).gameObject;
                DataSave data = dataGame[i];
                Debug.Log(data.DataName + "---" + data.SceneName + "---" + data.Px + "---" + data.Py + "---" + data.TyochinYR + "---" + data.TsutsuYR + "---" + data.HebiYR + "---" + data.Time + "---");
                g.transform.GetChild(0).GetComponent<Text>().text = data.DataName;
                if (data.HebiYR == 0)
                {
                    g.transform.GetChild(5).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    g.transform.GetChild(6).GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                }
                else
                {
                    g.transform.GetChild(5).GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                    g.transform.GetChild(6).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                }
                if (data.TsutsuYR == 0)
                {
                    g.transform.GetChild(7).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    g.transform.GetChild(8).GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                }
                else
                {
                    g.transform.GetChild(8).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    g.transform.GetChild(7).GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                }
                if (data.TyochinYR == 0)
                {
                    g.transform.GetChild(3).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    g.transform.GetChild(4).GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                }
                else
                {
                    g.transform.GetChild(4).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    g.transform.GetChild(3).GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                }
                g.transform.GetChild(9).GetComponent<Text>().text = data.SceneName;
                g.transform.GetChild(2).GetComponent<Text>().text = data.Time.ToString();
                g.transform.GetChild(1).GetComponent<Button>().AddEventListener(i, Load);
            }
        }
        else
        {
            transform.gameObject.SetActive(false);
        }
    }

    void Load(int index)
    {
        indexDataChange = index;
        Debug.Log("Load" + indexDataChange);

        notificationGameManager.DataShowLoad_Load(true);
        Debug.Log("Load" + index);
    }

}
