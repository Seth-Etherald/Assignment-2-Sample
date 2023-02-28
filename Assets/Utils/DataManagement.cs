using System;
using System.IO;
using UnityEngine;

public class DataManagement
{
    public EnemiesData[] ReadData(string saveFile)
    {
        EnemiesData[] enemies = null;
        if (File.Exists(saveFile))
        {
            string content = File.ReadAllText(saveFile);
            enemies = JsonHelper.FromJson<EnemiesData>(content);
        }
        else
        {
            File.Create(saveFile);
        }
        return enemies;
    }

    public void SaveData(EnemiesData[] enemies, string saveFile)
    {
        string content = JsonHelper.ToJson(enemies);
        File.WriteAllText(saveFile, content);
    }

    [Serializable]
    public class EnemiesData
    {
        public float positionX;
        public float positionY;
        public int healthPoint;
    }
}