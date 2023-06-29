using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private String[] items = new string[5];
    private int collectedItem = 0;

    [SerializeField] private int maxCollectedItem = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collectedItem > maxCollectedItem)
        {
            return;
        }
        
        if (collision.gameObject.CompareTag("Collectable"))
        {
            items[collectedItem++] = collision.gameObject.name;
            Destroy(collision.gameObject);
            for (int i = 0; i < collectedItem; i++)
            {
                Debug.Log(i + ": " + items[i]);
            }
            Debug.Log("----------------");
        }
    }
}
