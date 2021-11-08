using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChosing : MonoBehaviour
{
    public void TraininLevel()
    {
        SceneManager.LoadScene("TraininLevel");
    }
    public static void LoadLevelChoser()
    {
        SceneManager.LoadScene("LevelChoosing");
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}
