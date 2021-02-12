﻿using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate ()
        {
            OnClick(param);
        });
    }
}



public class DataUI : MonoBehaviour
{
    public DataManager dataManager;
    public NotificationGameManager notificationGameManager;
    private int checkDelete = 0;

    private int checkEdit = 0;


    private int indexDataChange = 0;

    public int CheckEdit { get => checkEdit; set => checkEdit = value; }

    public int CheckDelete { get => checkDelete; set => checkDelete = value; }
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

        if (dataManager.DataGame.Count != 0)
        {

            transform.gameObject.SetActive(true);
            GameObject child = transform.GetChild(0).gameObject;
            GameObject g;
            List<DataSave> dataGame = dataManager.DataGame;
            dataGame.Reverse();
            for (int i = 0; i < dataGame.Count; i++)
            {
                Instantiate(child, transform);
            }

            Destroy(child);
        }
        else
        {
            checkDelete = 1;
            transform.gameObject.SetActive(false);
        }
    }

    public void add_transform()
    {
        Instantiate(transform.GetChild(0).gameObject, transform);
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
                g.transform.GetChild(1).GetComponent<Button>().AddEventListener(i, Delete);
                g.transform.GetChild(2).GetComponent<Button>().AddEventListener(i, Edit);
                g.transform.GetChild(3).GetComponent<Button>().AddEventListener(i, Save);
            }
        }
        else
        {
            transform.gameObject.SetActive(false);
        }

    }

    public void delete_alltransform()
    {
        if (transform.childCount > 1)
        {
            for (int i = 1; i < transform.childCount; i++)
            {
                GameObject.Destroy(transform.GetChild(i).gameObject);
            }
        }
        CheckDelete = 1;

    }

    





    


     void Edit(int index)
    {
        checkEdit = 1;
        indexDataChange = index;
        Debug.Log("Edit" + indexDataChange);
        
        notificationGameManager.DataShow(false);
        notificationGameManager.DataMini(true);
    }
     void Delete(int index)
    {
        indexDataChange = index;
        Debug.Log("Delete" + indexDataChange);

        //notificationGameManager.DataShow(false);
        notificationGameManager.DataMiniDelete(true);
        
        Debug.Log("Delete"+index);
    }

     void Save(int index)
    {
        Debug.Log("Save"+index);
    }


    public void setDelete()
    {
 //       GameObject.Destroy(transform.GetChild(indexDataChange).gameObject);
    }

}
    
