using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerConector : MonoBehaviour
{

    private static int counter = 0;
    private static Collider2D data;
    private static void OnTriggerEnter2D()
    {
        switch (data.tag)
        {
            case "Star":
                counter++;
                Destroy(data.gameObject, 0.2f);
                Debug.Log(counter);
                break;
            case "Portal":
                //Заменить на LevelChosser.LoadLevel
                SceneManager.LoadScene("");

                break;
        }


        if (counter == 3)
        {
            Portal.isOpen = true;
        }

    }
}
