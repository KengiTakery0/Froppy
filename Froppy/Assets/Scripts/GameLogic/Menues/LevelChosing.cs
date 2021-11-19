using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChosing : MonoBehaviour
{   
    [SerializeField] private Button trainingLevel;
    [SerializeField] private Button level1;
    [SerializeField] private Button level2;
    //[SerializeField] private Button level3;

    private int LevelComplite;

    private void Start()
    {
       // trainingLevel.interactable = true;
        level1.interactable = true;
        level2.interactable = Saver.Levels[0].isPassed;
       // level3.interactable = false;

       /* switch (TriggerConector.portalCounter)
        {
            case 1:
                level1.interactable = true;
                break;
            case 2:
                level2.interactable = true;
                break;
        }*/
    }


    public static void LoadLevelChoser()
    {
        SceneManager.LoadScene("LevelChoosing");
    }
    public void TraininLevel()
    {
        SceneManager.LoadScene("TrainingLevel");
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
