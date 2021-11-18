using Mono.Data.Sqlite;
using UnityEngine;
using System.Data;
using System;

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
<<<<<<< HEAD
            bool b = dataReader.HasRows;
=======
            bool boolHasRecords = dataReader.HasRows;
>>>>>>> 6ca104d30f70822ebedd242a6bba51ebd6b557ca
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

<<<<<<< HEAD
    internal static LevelInfo[] GetLevels()
    {
        throw new NotImplementedException();
    }
=======
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

>>>>>>> 6ca104d30f70822ebedd242a6bba51ebd6b557ca
    public static void InsertLevels(LevelInfo[] levels)
    {
        string[] stringifyedLevels = new string[levels.Length];
        for (int i = 0; i < levels.Length; i++)
        {
            stringifyedLevels[i] = $"({i + 1}, '{JsonUtility.ToJson(levels[i])}')";
        }
        DB.Open();
        SqliteCommand cmd = connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO saves (level, data) VALUES {string.Join(",", stringifyedLevels)};";
        cmd.ExecuteNonQuery();
        DB.Close();
    }

}
