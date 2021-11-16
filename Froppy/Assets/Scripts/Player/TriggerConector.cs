using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerConector : MonoBehaviour
{

    private int collectCounter = 0;
    public static int portalCounter = 0;  
    private void OnTriggerEnter2D(Collider2D data)
    {
        switch (data.tag)
        {
            case "Star":
                collectCounter++;
                Destroy(data.gameObject, 0.1f);
                Debug.Log(collectCounter);
                break;
            case "Portal":
                portalCounter++;    
                LevelChosing.LoadLevelChoser();
                break;
        }
        if (collectCounter == 3)
        {
            Portal.isOpen = true;
        }

    }
}
