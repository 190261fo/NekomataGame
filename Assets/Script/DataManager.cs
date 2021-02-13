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

        public DataUI dataUI;
        public DataUI_Load dataUI_load;

        public List<DataSave> DataGame { get => dataGame; set => dataGame = value; }


        private void Start()
        {
            debug_log();


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

        


        public void DeleteDataCallMiniGame()
        {
            PlayerPrefs.DeleteKey("MiniGameMode1");
            PlayerPrefs.DeleteKey("MiniGameMode2");
            PlayerPrefs.DeleteKey("MiniGameMode3");
            PlayerPrefs.Save();
        }



        public void Save(int style,String dataname)
        {
            bf = new BinaryFormatter();
            fileStream = null;

            try
            {
                //　ゲームフォルダにfiledata.datファイルを作成
                fileStream = File.Create(Application.dataPath + "/filedata.dat");
                Debug.Log(Application.dataPath + "/filedata.dat");
                //　クラスの作成
                if(style == 1)
                {
                    Debug.Log("New");
                    DataSave datasave = new DataSave
                    (dataname,
                    SceneManager.GetActiveScene().name,
                    player.transform.position.x,
                    player.transform.position.y,
                    PlayerPrefs.GetInt("Tyouchin"),
                    PlayerPrefs.GetInt("Tsumu"),
                    PlayerPrefs.GetInt("RoratePuzzle"),                   
                    DateTime.Now
                    );
                    dataGame.Add(datasave);
                }
                if (style == 2)
                {
                    Debug.Log("Edit");
                    dataGame[dataUI.IndexDataChange].DataName = dataname;
                    dataGame[dataUI.IndexDataChange].Time = DateTime.Now;
                }
                if (style == 3)
                {
                    Debug.Log("SaveShortCut");
                    debug_data();
                    dataGame[dataUI.IndexDataChange].SceneName = SceneManager.GetActiveScene().name;
                    dataGame[dataUI.IndexDataChange].Px = player.transform.position.x;
                    dataGame[dataUI.IndexDataChange].Py = player.transform.position.y;
                    dataGame[dataUI.IndexDataChange].HebiYR  = PlayerPrefs.GetInt("RoratePuzzle");
                    dataGame[dataUI.IndexDataChange].TsutsuYR = PlayerPrefs.GetInt("Tsumu");
                    dataGame[dataUI.IndexDataChange].TyochinYR  = PlayerPrefs.GetInt("Tyouchin");
                    dataGame[dataUI.IndexDataChange].Time = DateTime.Now;


                }
                
                dataGame.Sort(Compare);
                dataGame.Reverse();


                bf.Serialize(fileStream, dataGame);
                Debug.Log("Saved");
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


        public void Save1()
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
                ("test",
                SceneManager.GetActiveScene().name,
                player.transform.position.x,
                player.transform.position.y,
                PlayerPrefs.GetInt("Tyouchin"),
                PlayerPrefs.GetInt("Tsumu"),
                PlayerPrefs.GetInt("RoratePuzzle"),              
                DateTime.Now
                );
                dataGame.Add(datasave);

                dataGame.Sort(Compare);
                dataGame.Reverse();


                bf.Serialize(fileStream, dataGame);
                Debug.Log("Saved");
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


        public void Delete(String style)
        {
            bf = new BinaryFormatter();
            fileStream = null;

            try
            {
                //　ゲームフォルダにfiledata.datファイルを作成
                fileStream = File.Create(Application.dataPath + "/filedata.dat");
                Debug.Log(Application.dataPath + "/filedata.dat");
                if (style.Equals("All"))
                {
                    dataGame.Clear();
                }
                else
                {
                    List<DataSave> dataGameCopy = dataGame;
                    Debug.Log("Vi tri Xoa" + dataUI.IndexDataChange);
                    dataGameCopy.RemoveAt(dataUI.IndexDataChange);
                    dataGameCopy.Sort(Compare);
                    dataGameCopy.Reverse();
                    dataGame = dataGameCopy;
                    Debug.Log("Sau khi xoa");
                    if (dataGame.Count != 0)
                    {
                        foreach (DataSave a in dataGame)
                        {
                            Debug.Log(a.DataName + "---" + a.SceneName + "---" + a.Px + "---" + a.Py + "---" + a.TyochinYR + "---" + a.TsutsuYR + "---" + a.HebiYR + "---" + a.Time + "---");
                        }
                    }
                }
               


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

        private static int Compare(DataSave x, DataSave y)
        {
            if (x.Time < y.Time)
            {
                return -1;
            }
            else if (x.Time > y.Time)
            {
                return 1;
            }
            return 0;
        }




        //Tsumu,RoratePuzzle,Tyouchin
        public void FillDataToGame()
        {
            LoadData();
            PlayerPrefs.SetFloat("p_x", dataGame[dataUI_load.IndexDataChange].Px);
            PlayerPrefs.SetFloat("p_y", dataGame[dataUI_load.IndexDataChange].Py);
            PlayerPrefs.SetInt("RoratePuzzle", dataGame[dataUI_load.IndexDataChange].HebiYR );
            PlayerPrefs.SetInt("Tsumu", dataGame[dataUI_load.IndexDataChange].TsutsuYR );
            PlayerPrefs.SetInt("Tyouchin", dataGame[dataUI_load.IndexDataChange].TyochinYR);
            SaveScene(dataGame[dataUI_load.IndexDataChange].SceneName);
            PlayerPrefs.SetInt("Saved", 1);         
            PlayerPrefs.Save();

        }

        public void LoadData()
        {
            Debug.Log("Loading");
            bf = new BinaryFormatter();
            fileStream = null;

            try
            {
                //　ファイルを読み込む
                fileStream = File.Open(Application.dataPath + "/filedata.dat", FileMode.Open);
                //　読み込んだデータをデシリアライズ
                List<DataSave> LoaddataGame = bf.Deserialize(fileStream) as List<DataSave>;

                dataGame = LoaddataGame;

                if(dataGame.Count != 0)
                {
                    foreach (DataSave a in dataGame)
                    {
                        Debug.Log(a.DataName + "---" + a.SceneName + "---" + a.Px + "---" + a.Py + "---" + a.TyochinYR + "---" + a.TsutsuYR + "---" + a.HebiYR + "---" + a.Time + "---");
                    }
                }

                Debug.Log("Loaded");
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

        






        public void debug_log()
        {
            Debug.Log("X : " + PlayerPrefs.GetFloat("p_x"));
            Debug.Log("Y : " + PlayerPrefs.GetFloat("p_x"));
            Debug.Log("Scene : " + PlayerPrefs.GetString("Scene"));
            Debug.Log("Load : " + PlayerPrefs.GetInt("Load"));
            Debug.Log("Saved : " + PlayerPrefs.GetInt("Saved"));
        }


        public void debug_data()
        {
            

            Debug.Log("Check Yoryouku");
            Debug.Log("RoratePuzzle : " + PlayerPrefs.GetInt("RoratePuzzle"));
            Debug.Log("Tsumu  : " + PlayerPrefs.GetInt("Tsumu"));
            Debug.Log("Tyouchin : " +  PlayerPrefs.GetInt("Tyouchin"));
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

