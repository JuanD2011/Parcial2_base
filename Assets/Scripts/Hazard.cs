using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Hazard : MonoBehaviour
{
    public delegate void WriteHazard();
    public static event WriteHazard OnWriteDeaths;

    private Collider2D myCollider;
    protected Rigidbody2D myRigidbody;

    [SerializeField]
    private float resistance = 1F;

    private int damage = 1;

    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
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
            resistance -= 1;

            if (resistance == 0)
            {
                OnHazardDestroyed();
            }
        }
        else
        {
            if (!(collision.gameObject.name == "Barrerini"))
            {
                OnHazardDestroyed(); 
            }
        }
        OnWriteDeaths();
    }

    protected void OnHazardDestroyed()
    {
        StartCoroutine(SpinToDeath());
    }

    protected virtual IEnumerator SpinToDeath()
    {
        yield return null;
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}