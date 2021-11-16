using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
using Mono.Data.Sqlite;
using UnityEngine;
using System.IO;

public static class SqlConnection
{
    public static SqliteConnection connection;
    private static string dbPath;
    private static SqliteCommand command;
    private static string file = "/SqliteDatabase/Froppy.";

    public static void SetConnection()
    {
        dbPath = Application.dataPath + file;
        connection = new SqliteConnection("URI=file:" +dbPath);
        connection.Open();  
    }
    public static void CloseConnection()
    {
        connection.Close();
        command.Dispose();
    }

    public static void SavePLayerPos( float posX , float posY)
    {
        if (connection.State == ConnectionState.Open)
        {
            command = new SqliteCommand();
            command.Connection = connection;
            Debug.Log($"INSERT INTO PlayerPosition(Position_X, Position_Y) VALUES({posX},{posY})");
            command.CommandText = @$"INSERT INTO PlayerPosition (Position_X,Position_Y) VALUES ({posX},{posY})";
/*            command.Parameters.Add(new SqliteParameter("X", posX));
            command.Parameters.Add(new SqliteParameter("Y", posY));*/
            command.ExecuteNonQuery();
        }
        
    }

}
