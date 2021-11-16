using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneChanger : MonoBehaviour
{

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
    public void LoadLevelChosingMenu()
    {
        SceneManager.LoadScene("LevelChoosing");
    }

}
