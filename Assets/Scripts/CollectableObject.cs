using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectableObject : MonoBehaviour
{
    [SerializeField] private float x0, x1, z0, z1;

    [SerializeField] private GameObject[] generatedObjects;
    // Start is called before the first frame update
    private void OnDestroy()
    {
        foreach (GameObject item in generatedObjects)
        {
            float x = Random.Range(x0, x1);
            float z = Random.Range(z0, z1);
            Instantiate(item, new Vector3(x, 5, z), Quaternion.identity);
        }
    }
}
