using Fungus;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Script
{
    public class DataManager : MonoBehaviour
    {


        //public Flowchart flowchart1;
        //public Flowchart flowchart2;
        //public NekomataController nekomata;
        //// Use this for initialization
        //void Start()
        //{
        //    Debug.Log(Application.persistentDataPath);
        //}

        //// Update is called once per frame
        //void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.S))
        //    {
        //        Save();
        //    }

        //    if (Input.GetKeyDown(KeyCode.L))
        //    {
        //        Load();
        //    }
        //    //if (flowchart1.GetBooleanVariable("IsTalking") || flowchart2.GetBooleanVariable("IsTalking"))
        //    //{
        //    //Save();    
        //    //}
        //}
        //private void Load()
        //{
        //    string path = Application.persistentDataPath + "/SaveData.dat";
        //    if (File.Exists(path))
        //    {
        //        BinaryFormatter bf = new BinaryFormatter();
        //        FileStream file = new FileStream(path, FileMode.Open);
        //        int a =   (int) bf.Deserialize(file) ;
        //        Debug.Log(a);



        //    }
        //    else
        //    {
        //        Debug.LogError("Save file not found in" + path);

        //    }

        //}

        //private void LoadPlayer(SaveData data)
        //{
        //    nekomata.UpdateData(data);
        //}

        //private void Save()
        //{
        //    BinaryFormatter bf = new BinaryFormatter();
        //    string path = Application.persistentDataPath + "/SaveData.dat";
        //    FileStream file = new FileStream(path, FileMode.Create);


        //    //SaveData data = new SaveData();

        //    bf.Serialize(file, 1);

        //    file.Close();



        //}

        //private SaveData SavePlayer(SaveData Data)
        //{
        //    Data.NekomataData = new PlayerData(nekomata.rigidbody2d.position);
        //    return Data;
        //}

        public GameObject player;
        private void Start()
        {
            if (PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("Load") == 1)
            {
                float pX = player.transform.position.x;
                float pY = player.transform.position.y;

                pX = PlayerPrefs.GetFloat("p_x");
                pY = PlayerPrefs.GetFloat("p_y");
                player.transform.position = new Vector2(pX, pY);
                PlayerPrefs.SetInt("Load", 0);
                PlayerPrefs.Save();
            }
        }




        public void SaveGame()
        {
            PlayerPrefs.SetFloat("p_x", player.transform.position.x);
            PlayerPrefs.SetFloat("p_y", player.transform.position.y);
            PlayerPrefs.SetInt("Saved", 1);
            SaveScene(SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();
        }


        public void SetLoad()
        {
            PlayerPrefs.SetInt("Load", 1);
            PlayerPrefs.Save();
        }


        public void LoadPosition()
        {
            
            float pX = player.transform.position.x;
            float pY = player.transform.position.y;

            pX = PlayerPrefs.GetFloat("p_x");
            pY = PlayerPrefs.GetFloat("p_y");
            player.transform.position = new Vector2(pX, pY);
            
            SetLoad();
        }

        public void SaveScene(String SceneName)
        {
            PlayerPrefs.SetString("Scene", SceneName);
            PlayerPrefs.Save();
        }


        public void SaveSceneTitle()
        {
            PlayerPrefs.SetString("TitleScene", "TitleScene");
            PlayerPrefs.Save();
        }


        //Tsumu,RoratePuzzle,Tyouchin











    }
}