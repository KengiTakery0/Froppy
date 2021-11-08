using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChosser : MonoBehaviour
{
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}
