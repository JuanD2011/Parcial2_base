using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private Collider2D myCollider;
    private Rigidbody2D myRigidbody;

    protected float force = 10F;

    [SerializeField]
    private WaitForSeconds autoGoBack = new WaitForSeconds(3);

    protected virtual void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void AddForce(Rigidbody2D _mRigidbody) {
        _mRigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    public IEnumerator GoBack() {
        yield return autoGoBack;
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}