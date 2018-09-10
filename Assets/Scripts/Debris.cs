using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : Hazard
{
    private float vel;

    protected override void Start()
    {
        base.Start();
        vel = Random.Range(120, 180);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, vel * Time.deltaTime));
    }

    protected override IEnumerator SpinToDeath()
    {
        return base.SpinToDeath();
    }
}
