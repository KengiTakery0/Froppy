using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public static bool isOpen;
    [SerializeField] private GameObject portalPref;


    private Vector2 pos;
    void Start()
    {
        pos = GetComponent<Vector2>();
    }

    void Update()
    {
        pos = new Vector2();
        if (isOpen)
        {
            GameObject portPos = Instantiate(portalPref);

            portPos.transform.position = new Vector2(transform.position.x, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Portal")
        {
            
        }
    }
}
