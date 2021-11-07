using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    private int counter = 0;

    private void OnTriggerEnter2D(Collider2D data)
    {

        if (data.tag == "Star")
        {
            counter++;
            Destroy(data.gameObject, 0.5f);
            Debug.Log(counter);

        }
        if (counter == 3)
        {
            Portal.isOpen = true;
        }

    }
}
