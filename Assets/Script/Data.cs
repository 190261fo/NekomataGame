using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public DataManager dataManager;
    // Start is called before the first frame update
    void Start()
    {
        List<int> a = new List<int>();
        a.Add(1);
        a.Add(2);
        a.Add(3);
        a.Add(4);
        a.Add(5);
        a.Reverse();
        foreach(int i in a)
        {
            Debug.Log(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowData()
    {
        dataManager.Load();
        resetContent();
        if (dataManager.DataGame.Count != 0)
        {
            
            //resetContent();
            GameObject child = transform.GetChild(0).gameObject;
            GameObject g;
            List<DataSave> dataGame = dataManager.DataGame;
            dataGame.Reverse();
            for (int i = 0; i < dataGame.Count; i++)
            {
                DataSave data = dataGame[i];
                Debug.Log(data.DataName + "---" + data.SceneName + "---" + data.Px + "---" + data.Py + "---" + data.TyochinYR + "---" + data.TsutsuYR + "---" + data.HebiYR + "---" + data.Time + "---");
                g = Instantiate(child, transform);
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
            }

            Destroy(child);
        }
    }


    public void resetContent()
    {
        
        if (transform.childCount>1)
        {
            for (int i = 1; i < transform.childCount; i++)
            {
                GameObject.Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
