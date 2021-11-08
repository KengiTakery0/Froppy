using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelChosser
{
    public static void TraininLevel()
    {
        SceneManager.LoadScene("");
    }
    public static void LoadLevelChoser()
    {
        SceneManager.LoadScene("LevelChoosing");
    }
    public static void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public static void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public static void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public static void LoadLevel4()
    {
        SceneManager.LoadScene("Level4");
    }

}
