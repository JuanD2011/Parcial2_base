using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : Hazard
{
    float speed = 1;
    private Rigidbody2D rigidbody2D;
    protected override void Start()
    {
        base.Start();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigidbody2D.MoveRotation(Random.Range(10, 50) * Time.deltaTime);
    }
}
