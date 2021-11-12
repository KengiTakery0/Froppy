using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChecker : MonoBehaviour
{
    private void SetWalled()
    {
        transform.parent.GetComponent<PlayerController>().SetCanJumpfromWall(true);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        transform.parent.GetComponent<PlayerController>().setWalled(true);
        if (transform.gameObject.name == "Map") Invoke("SetWalled", 0.3f);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        transform.parent.GetComponent<PlayerController>().setWalled(false);
        transform.parent.GetComponent<PlayerController>().SetCanJumpfromWall(false);
        CancelInvoke("SetWalled");
    }
}
