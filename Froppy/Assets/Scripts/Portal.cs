using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public static bool isOpen;
    [SerializeField] private GameObject portalPref;

    void Update()
    {
        
        if (isOpen)
        {
            portalPref.SetActive(true);
        }
    }

    
}
