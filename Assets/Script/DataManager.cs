using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Script
{
    public class DataManager : MonoBehaviour
    {
        private List<DataSave> dataGame = new List<DataSave>();
        private FileStream fileStream;
        private BinaryFormatter bf;
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

        public void setMoveData()
        {
            PlayerPrefs.SetInt("nekoMove", 0);
            PlayerPrefs.Save();
            Debug.Log("move");
        }


        public void DeleteDataCallMiniGame()
        {
            PlayerPrefs.DeleteKey("MiniGameMode1");
            PlayerPrefs.DeleteKey("MiniGameMode2");
            PlayerPrefs.DeleteKey("MiniGameMode3");
            PlayerPrefs.Save();
        }


        //Tsumu,RoratePuzzle,Tyouchin

        public void Save(String dataname)
        {
            bf = new BinaryFormatter();
            fileStream = null;

            try
            {
                //　ゲームフォルダにfiledata.datファイルを作成
                fileStream = File.Create(Application.dataPath + "/filedata.dat");
                Debug.Log(Application.dataPath + "/filedata.dat");
                //　クラスの作成

                DataSave datasave = new DataSave
                (dataname,
                SceneManager.GetActiveScene().name,
                player.transform.position.x,
                player.transform.position.y,
                PlayerPrefs.GetInt("Tsumu"),
                PlayerPrefs.GetInt("RoratePuzzle"),
                PlayerPrefs.GetInt("Tyouchin"),
                DateTime.Now
                );

                //FullData.Add(data);


                //　入力フィールドのテキストをクラスのデータに保存
                //data.dataText = inputField.text;
                //　ファイルにクラスを保存
                dataGame.Add(datasave);


                bf.Serialize(fileStream, dataGame);
                Debug.Log("Đã Lưu");
            }
            catch (IOException e)
            {
                Debug.Log("ファイルオープンエラー");
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }


        public void Load()
        {
            Debug.Log("Chưa đến nơi");
            bf = new BinaryFormatter();
            fileStream = null;

            try
            {
                //　ファイルを読み込む
                fileStream = File.Open(Application.dataPath + "/filedata.dat", FileMode.Open);
                //　読み込んだデータをデシリアライズ
                List<DataSave> LoaddataGame = bf.Deserialize(fileStream) as List<DataSave>;

                dataGame = LoaddataGame;

                foreach (DataSave a in dataGame)
                {
                    Debug.Log(a.DataName + "---" + a.SceneName + "---" + a.Px + "---" + a.Py + "---" + a.TyochinYR + "---" + a.TsutsuYR + "---" + a.HebiYR + "---" + a.Time + "---");
                }
                //Debug.Log(dataSave.Name + "vs" + dataSave.Age);
                Debug.Log("đến nơi");
            }
            catch (FileNotFoundException e)
            {
                Debug.Log("ファイルがありません");
            }
            catch (IOException e2)
            {
                Debug.Log("ファイルオープンエラー");
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }

        }

    }

    [Serializable]
    public class DataSave
    {
        private string dataName;
        private string sceneName;
        private float px;
        private float py;
        private int tyochinYR;
        private int tsutsuYR;
        private int hebiYR;
        private DateTime time;



        public DataSave(String DataName, String SceneName, float px, float py, int tyochinYR, int tsutsuYR, int hebiYR, DateTime time)
        {
            this.DataName = DataName;
            this.SceneName = SceneName;
            this.Px = px;
            this.Py = py;
            this.TyochinYR = tyochinYR;
            this.TsutsuYR = tsutsuYR;
            this.HebiYR = hebiYR;
            this.Time = time;
        }

        public string DataName { get => dataName; set => dataName = value; }
        public string SceneName { get => sceneName; set => sceneName = value; }
        public float Px { get => px; set => px = value; }
        public float Py { get => py; set => py = value; }
        public int TyochinYR { get => tyochinYR; set => tyochinYR = value; }
        public int TsutsuYR { get => tsutsuYR; set => tsutsuYR = value; }
        public int HebiYR { get => hebiYR; set => hebiYR = value; }
        public DateTime Time { get => time; set => time = value; }

        
    }
}

