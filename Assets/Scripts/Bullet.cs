using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private Collider2D myCollider;
    private Rigidbody2D myRigidbody;

    [SerializeField]
    private float force = 10F;

    [SerializeField]
    private float autoDestroyTime = 5F;

    // Use this for initialization
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();

        myRigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);

        Invoke("AutoDestroy", autoDestroyTime);
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
    }
}