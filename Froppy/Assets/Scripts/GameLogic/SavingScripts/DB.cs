using Mono.Data.Sqlite;
using UnityEngine;
using System.Data;
using System;
using System.Collections.Generic;

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
            bool b = dataReader.HasRows;
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

    public static LevelInfo[] GetLevels()
    {
        List<LevelInfo> list = new List<LevelInfo>();
        DB.Open();
        SqliteCommand cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT data FROM saves ORDER BY level";
        using SqliteDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            LevelInfo li = JsonUtility.FromJson<LevelInfo>(rd.GetString(0));
            list.Add(li);
        }
        rd.Close();
        DB.Close();
        return list.ToArray();
    }

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

    public static void SaveLevels(LevelInfo[] levels)
    {
        DB.Open();
        for (int i = 0; i < levels.Length; i++)
        {
            string level = (i + 1).ToString();
            string data = JsonUtility.ToJson(levels[i]);
            SqliteCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"UPDATE saves SET data = '{data}' WHERE level = {level};";
            cmd.ExecuteNonQuery();
        }
        DB.Close();
    }

}
