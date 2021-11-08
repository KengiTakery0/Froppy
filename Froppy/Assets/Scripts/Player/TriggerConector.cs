using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerConector : MonoBehaviour
{

    private int counter = 0;
    private void OnTriggerEnter2D(Collider2D data)
    {
        switch (data.tag)
        {
            case "Star":
                counter++;
                Destroy(data.gameObject, 0.1f);
                Debug.Log(counter);
                break;
            case "Portal":
                LevelChosser.LoadLevelChoser();
                break;
        }
        if (counter == 3)
        {
            Portal.isOpen = true;
        }

    }
}
