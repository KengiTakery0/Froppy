using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private int levelIndex;

    void Start()
    {
        Saver.Level = Saver.Levels[levelIndex - 1];
        LoadLevel();
        InvokeRepeating("SaveLevel", 0.5f, 0.5f);
    }

    private void SaveLevel()
    {
        Saver.Level.playerData.x = playerController.transform.position.x;
        Saver.Level.playerData.y = playerController.transform.position.y;

        Saver.Save();
    }

    private void LoadLevel()
    {
        playerController.transform.position = new Vector2(Saver.Level.playerData.x, Saver.Level.playerData.y);
    }
}
