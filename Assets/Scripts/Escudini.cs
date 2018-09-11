using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudini : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.GetComponent<Hazard>())
        //{
        //    HazardsPool.SharedInstance.ResetHazard(collision.gameObject);
        //}
        Destroy(gameObject);
    }
}
