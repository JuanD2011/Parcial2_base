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

    [SerializeField]
    protected float force = 10F;

    [SerializeField]
    //private float autoDestroyTime = 5F;
    private WaitForSeconds autoGoBack = new WaitForSeconds(3);

    protected virtual void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();

        //myRigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);

        //Invoke("AutoDestroy", autoDestroyTime);
        //Invoke("GoBack", autoGoBack);
    }

    public void AddForce(Rigidbody2D _mRigidbody) {
        _mRigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    public IEnumerator GoBack() {
        yield return autoGoBack;
        gameObject.SetActive(false);
    }

    /*private void AutoDestroy()
    {
        Destroy(gameObject);
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}