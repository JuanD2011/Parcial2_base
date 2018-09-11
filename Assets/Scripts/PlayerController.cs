using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    public delegate void GameOver();
    public static event GameOver OnGameOver;

    [SerializeField]
    private float speed;

    private float movementFactor;
    private bool canFire = true;
    private float coolDownTime = 0.5F;
    private Collider2D myCollider;

    protected bool InsideCamera(bool positive)
    {
        float direction = positive ? 1F : -1F;
        Vector3 cameraPoint = Camera.main.WorldToViewportPoint(
            new Vector3(
                myCollider.bounds.center.x + myCollider.bounds.extents.x * direction,
                0F,
                0F));
        return cameraPoint.x >= 0F && cameraPoint.x <= 1F;
    }

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        movementFactor = Input.GetAxis("Horizontal");

        if (InsideCamera(movementFactor > 0F) && movementFactor != 0F)
        {
            transform.position += new Vector3(movementFactor * speed * Time.deltaTime, 0F, 0F);
        }

        if (Input.GetButtonDown("Fire1") && canFire)
        {
            SpawnBullet();
            print("Fiyah!");
            StartCoroutine("FireCR");
        }
        if (Input.GetButtonDown("Fire2") && canFire)
        {
            SpawnAPBullet();
            print("Fiyah!");
            StartCoroutine("FireCR");
        }

        if (Input.GetKeyDown(KeyCode.Space) && BarreriniAb.canBarrerini) {
            AddBarreriniAb();
        }

        if (PoweriniAb.canPowerini && Input.GetButtonDown("Fire3")) {
            AddPoweriniAb();
        }
    }

    void SpawnBullet()
    {
        GameObject bullet = BulletPool.SharedInstance.GetBullet();
        if (bullet != null)
        {
            bullet.SetActive(true);
            bullet.transform.position = transform.position + new Vector3(0, 0.5f, 0);
            bullet.GetComponent<Bullet>().AddForce(bullet.GetComponent<Rigidbody2D>());
            StartCoroutine(bullet.GetComponent<Bullet>().GoBack());
        }
    }

    void SpawnAPBullet()
    {
        GameObject aPBullet = BulletPool.SharedInstance.GetAPBullet();
        if (aPBullet != null)
        {
            aPBullet.SetActive(true);
            aPBullet.transform.position = transform.position + new Vector3(0, 0.5f, 0);
            aPBullet.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            aPBullet.GetComponent<APBullet>().AddForce(aPBullet.GetComponent<Rigidbody2D>());
            StartCoroutine(aPBullet.GetComponent<APBullet>().GoBack());
        }
    }

    private void OnDestroy()
    {
        StopCoroutine("FireCR");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hazard>() != null)
        {
            OnGameOver();
        }

        if (collision.gameObject.CompareTag("Escudini"))
        {
            AddEscudiniAb();
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator FireCR()
    {
        canFire = false;
        yield return new WaitForSeconds(coolDownTime);
        canFire = true;
    }

    void AddBarreriniAb()
    {
        gameObject.AddComponent(typeof(BarreriniAb));
    }
    
    void AddPoweriniAb()
    {
        gameObject.AddComponent(typeof(PoweriniAb));
    }

    void AddEscudiniAb()
    {
        gameObject.AddComponent(typeof(EscudiniAb));
    }
}

