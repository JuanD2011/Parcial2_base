using System.Collections;
using UnityEngine;

public class Invader : Hazard
{
    Vector3 spawnPoint;
    bool direction = true;
    float time = 1;
    float movementRadius;
    float deathAnimTime = 2f;
    bool dead;

    public float MovementRadius
    {
        set
        {
            movementRadius = value;
        }
    }

    protected override void Start()
    {
        base.Start();
        spawnPoint = transform.position;
    }

    private void Update()
    {
        if (!dead)
        {
            if (transform.position.x <= spawnPoint.x - movementRadius)
            {
                transform.position = new Vector3(Mathf.PingPong(Time.time, 1.25f), transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(-Mathf.PingPong(Time.time, 1.25f), transform.position.y, transform.position.z);
            } 
        }
    }

    protected override IEnumerator SpinToDeath()
    {
        dead = true;
        myRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        GetComponent<Collider2D>().enabled = false;
        float elapsedTime = 0;
        while(elapsedTime <= deathAnimTime)
        {
            elapsedTime += Time.deltaTime;
            transform.Rotate(new Vector3(0, 0, 200 * Time.deltaTime));
            yield return null;
        }
        Destroy(gameObject);
    }
}
