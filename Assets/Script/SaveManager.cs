using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Script
{
    public class SaveManager : MonoBehaviour
    {
        public NekomataController nekomata;
        // Use this for initialization
        void Start()
        {
            Debug.Log(Application.persistentDataPath);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SavePosotion()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/" + "SaveData.dat",FileMode.OpenOrCreate);



            }

            catch(System.Exception)
            {

            }
        }
    }
}