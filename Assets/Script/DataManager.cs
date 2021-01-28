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

        public GameObject player;
        private void Start()
        {
            Debug.Log("X : " + PlayerPrefs.GetFloat("p_x"));
            Debug.Log("Y : " + PlayerPrefs.GetFloat("p_x"));
            Debug.Log("Scene : " + PlayerPrefs.GetString("Scene"));
            Debug.Log("Load : " + PlayerPrefs.GetInt("Load"));
            Debug.Log("Saved : " + PlayerPrefs.GetInt("Saved"));


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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("X : " + PlayerPrefs.GetFloat("p_x"));
                Debug.Log("Y : " + PlayerPrefs.GetFloat("p_x"));
                Debug.Log("Scene : " + PlayerPrefs.GetString("Scene"));
                Debug.Log("Load : " + PlayerPrefs.GetInt("Load"));
                Debug.Log("Saved : " + PlayerPrefs.GetInt("Saved"));
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

        public void DeleteData()
        {
            PlayerPrefs.DeleteKey("p_x");
            PlayerPrefs.DeleteKey("p_y");
            PlayerPrefs.DeleteKey("Load");
            PlayerPrefs.DeleteKey("Saved");
            PlayerPrefs.DeleteKey("Tsumu");
            PlayerPrefs.DeleteKey("RoratePuzzle");
            PlayerPrefs.DeleteKey("Tyouchin");
            PlayerPrefs.DeleteKey("Scene");
            PlayerPrefs.Save();
        }


        //Tsumu,RoratePuzzle,Tyouchin











    }
}