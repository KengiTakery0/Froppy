using Mono.Data.Sqlite;
using System;
using UnityEngine;
using System.Data;

public static class DB
{
    public static string DatabasePath;

    private static SqliteConnection connection;
    public static bool HasRecords
    {
        get
        {
            DB.Open();
            using SqliteDataReader dataReader = DB.SelectAll("saves");
            bool boolHasRecords = dataReader.HasRows;
            DB.Close();
            return boolHasRecords;
        }
    }

    private static SqliteDataReader SelectAll(string table)
    {
        SqliteCommand cmd = connection.CreateCommand();
        cmd.CommandText = $"SELECT * FROM {table}";
        return cmd.ExecuteReader();
    }

    private static void Close()
    {
        if (connection.State == ConnectionState.Open)
            connection.Close();
        connection = null;
    }

    private static void Open()
    {
        connection = new SqliteConnection("URI=file:" + Application.dataPath + DatabasePath);
        connection.Open();
    }

    public static string GetLevels(LevelInfo[] levels)
    {
/*        string[] levelsinfo = new string[levels.Length];
        for (int i = 0; i < levelsinfo.Length; i++)
        {
           levelsinfo[i] = $"({i+1},'{JsonUtility.FromJson<LevelInfo[]>(stringifyedLevels)}')";
        }*/
        DB.Open();
        SqliteCommand cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT * FROM saves";;
        DB.Close();
        throw new NotImplementedException();
    }

    public static void InsertLevels(LevelInfo[] levels)
    {
        string[] stringifyedLevels = new string[levels.Length];
        for (int i = 0; i < levels.Length; i++)
        {
            stringifyedLevels[i] = $"({i+1}, '{JsonUtility.ToJson(levels[i])}')";            
        }
        DB.Open();
        SqliteCommand cmd = connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO saves (level, data) VALUES {string.Join(",", stringifyedLevels)};";
        cmd.ExecuteNonQuery(); 
        DB.Close();
    }
}
