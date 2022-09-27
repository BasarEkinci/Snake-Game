using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Food : MonoBehaviour
{
    public BoxCollider gridAarea;


    private void Start()
    {
        RandomizePosition();
    }
    private void RandomizePosition()
    {
        Bounds bounds = this.gridAarea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);

        this.transform.position = new Vector3(Mathf.Round(x), 1.26f, Mathf.Round(z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            RandomizePosition();
        }
    }
}
