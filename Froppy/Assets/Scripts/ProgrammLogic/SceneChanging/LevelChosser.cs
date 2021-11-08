using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChosser : MonoBehaviour
{
    public void TraininLevel()
    {
        SceneManager.LoadScene("");
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
   
    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
}
