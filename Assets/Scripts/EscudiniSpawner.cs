using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudiniSpawner : MonoBehaviour {

    private Collider2D myCollider;

    [SerializeField]
    private float spawnFrequency = 1F;

    [SerializeField]
    private GameObject escudiniTemplate;

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();

        InvokeRepeating("SpawnEscudini", 0.2F, spawnFrequency);
    }

    private void SpawnEscudini()
    {
        if (escudiniTemplate != null)
        {
            Instantiate(escudiniTemplate, myCollider.GetPointInVolume(), transform.rotation);
        }
        else
        {
            CancelInvoke("SpawnEscudini");
        }
    }
}
