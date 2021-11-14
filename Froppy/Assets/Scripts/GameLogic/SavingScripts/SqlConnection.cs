using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
using Mono.Data.Sqlite;
using UnityEngine;



public static class SqlConnection
{
    public static SqliteConnection connection;
    private static string dbPath;
    private static SqliteCommand command;

    public static void SetConnection()
    {
        dbPath = Application.dataPath + "/SqliteDatabase/Froppydb.bytes";
        connection = new SqliteConnection(dbPath);
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
            command.CommandText = @"INSERT INTO PlayerPosition (Position_X,Position_Y) VALUES (X,Y)";
            command.Parameters.Add(new SqliteParameter("X", PlayerController.positionX));
            command.Parameters.Add(new SqliteParameter("Y", PlayerController.positionY));
            command.ExecuteNonQuery();
        }
    }

}
