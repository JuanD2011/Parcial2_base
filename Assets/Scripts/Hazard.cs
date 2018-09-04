using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Hazard : MonoBehaviour
{
    private Collider2D myCollider;
    private object myRigidbody;

    [SerializeField]
    private float resistance = 1F;

    private float spinTime = 1F;

    [SerializeField]
    private int damage = 1;

    public int Damage
    {
        get
        {
            return damage;
        }
    }

    // Use this for initialization
    protected virtual void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            //TODO: Make this to reduce damage using Bullet.damage attribute
            resistance -= 1;

            if (resistance == 0)
            {
                OnHazardDestroyed();
            }
        }
    }

    protected void OnHazardDestroyed()
    {

        //TODO: GameObject should spin for 'spinTime' secs. then disappear
        Destroy(gameObject);
    }
}