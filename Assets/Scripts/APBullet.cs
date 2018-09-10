using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APBullet : Bullet {

	protected override void Start ()
    {
        force = 5f;
        base.Start();
	}
}
