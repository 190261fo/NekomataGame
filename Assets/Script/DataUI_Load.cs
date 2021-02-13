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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void fill_transform()
    {
        dataManager.Load();

        if (dataManager.DataGame.Count >= 1)
        {

            transform.gameObject.SetActive(true);
            GameObject child = transform.GetChild(0).gameObject;

            for (int i = 0; i < dataManager.DataGame.Count; i++)
            {
                Instantiate(child, transform);
            }

            Destroy(child);
        }
        else
        {
            transform.gameObject.SetActive(false);
        }


    }

    

    public void fill_Data()
    {
        dataManager.Load();
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
                    g.transform.GetChild(6).GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                }
                if (data.TsutsuYR == 0)
                {
                    g.transform.GetChild(8).GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                }
                if (data.TyochinYR == 0)
                {
                    g.transform.GetChild(10).GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                }
                g.transform.GetChild(11).GetComponent<Text>().text = data.SceneName;
                g.transform.GetChild(4).GetComponent<Text>().text = data.Time.ToString();
                g.transform.GetChild(1).GetComponent<Button>().AddEventListener(i, Load);
            }
        }
        else
        {
            transform.gameObject.SetActive(false);
        }

        void Load(int index)
        {
            indexDataChange = index;
            Debug.Log("Load" + indexDataChange);

            notificationGameManager.DataShowLoad_Load(true);
            Debug.Log("Load" + index);
        }


    }
}
