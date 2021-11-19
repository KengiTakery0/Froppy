using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saver : MonoBehaviour
{
    public static LevelInfo[] Levels;
    public static LevelInfo Level;

    [SerializeField] private string databasePath = "/SqliteDatabase/Froppy.sqlite3";

    void Start()
    {
        DB.DatabasePath = databasePath;
       
        if (DB.HasRecords) LoadSave();
        else IniSave();
    }

    private void IniSave()
    {
        List<LevelInfo> levels = new List<LevelInfo>();
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings - 3; i++)
        {
            LevelInfo level = new LevelInfo() { playerData = new PlayerData() { x = 0, y = 0 } };
            levels.Add(level);
        }
        Levels = levels.ToArray();
        Debug.Log(Levels.Length);
        DB.InsertLevels(Levels);
    }

    private static void LoadSave()
    {
        Levels = DB.GetLevels();
    }

    public static void Save()
    {
        Debug.Log(Level.playerData.x);
        Debug.Log(Levels[1].playerData.x);
        DB.SaveLevels(Levels);
    }
}
