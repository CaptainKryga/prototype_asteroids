using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Model.Game;
using UnityEngine;

namespace Model.Save
{
    public class LoadSave : MonoBehaviour
    {
        private string _path;
        [SerializeField] private string _fileName;

        private void Start()
        {
            _path = Application.persistentDataPath + "/";

            Debug.Log(_path + _fileName);
        }

        public Level[] Load()
        {
            if (!File.Exists(_path + _fileName))
            {
                Debug.Log("Create new random file");

                return CreateNewSave();
            }
            else
            {
                Debug.Log("Load old file");

                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(_path + _fileName, FileMode.Open);

                SaveData saveData = (SaveData) bf.Deserialize(file);

                file.Close();

                return DeserializeSaveData(saveData);
            }
        }
        
        public void Save(Level[] levels)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(_path + _fileName, FileMode.OpenOrCreate);
            
            bf.Serialize(file, SerializeSaveData(levels));
            file.Close();
        }

        private Level[] CreateNewSave()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(_path + _fileName);

            Level[] levels = new Level[3];
            for (int x = 0; x < levels.Length; x++)
                levels[x] = new Level(x);

            bf.Serialize(file, SerializeSaveData(levels));
            file.Close();

            return levels;
        }
        
        private Level[] DeserializeSaveData(SaveData saveData)
        {
            Level[] levels = new Level[saveData.Length];

            for (int x = 0; x < levels.Length; x++)
            {
                levels[x] = new Level(saveData.Status[x], saveData.Size[x], saveData.SpawnDelay[x],
                    saveData.Speed[x], saveData.LifeCount[x], saveData.Distance[x]);
            }

            return levels;
        }

        private SaveData SerializeSaveData(Level[] levels)
        {
            SaveData saveData = new SaveData(levels.Length);
            saveData.Status = new GameTypes.ELevel[saveData.Length];
            saveData.Size = new float[saveData.Length];
            saveData.SpawnDelay = new float[saveData.Length];
            saveData.Speed = new float[saveData.Length];
            saveData.LifeCount = new int[saveData.Length];
            saveData.Distance = new float[saveData.Length];

            for (int x = 0; x < saveData.Length; x++)
            {
                saveData.Status[x] = levels[x].Status;
                saveData.Size[x] = levels[x].Size;
                saveData.SpawnDelay[x] = levels[x].SpawnDelay;
                saveData.Speed[x] = levels[x].Speed;
                saveData.LifeCount[x] = levels[x].LifeCount;
                saveData.Distance[x] = levels[x].Distance;
            }

            return saveData;
        }
    }
}