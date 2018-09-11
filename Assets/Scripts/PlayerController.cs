using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float movementFactor;
    private bool canFire = true;
    private float coolDownTime = 0.5F;
    private Collider2D myCollider;
    private bool canBarrerini = true;
    private WaitForSeconds cooldownBarrerini = new WaitForSeconds(5);
    private WaitForSeconds barreriniDuration = new WaitForSeconds(5);
    private WaitForSeconds escudiniDuration = new WaitForSeconds(5);
    private WaitForSeconds poweriniCooldown = new WaitForSeconds(10);
    private bool canPowerini = true;

    [SerializeField]
    private Object bulletGO;
    [SerializeField] private GameObject apBullet;

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

        if (bulletGO != null && Input.GetButtonDown("Fire1") && canFire)
        {
            //Instantiate(bulletGO, transform.position + (transform.up * 0.5F), Quaternion.identity);
            SpawnBullet();
            print("Fiyah!");
            StartCoroutine("FireCR");
        }
        if (bulletGO != null && Input.GetButtonDown("Fire2") && canFire)
        {
            //Instantiate(apBullet, transform.position + (transform.up * 0.5F), Quaternion.identity);
            SpawnAPBullet();
            print("Fiyah!");
            StartCoroutine("FireCR");
        }
        if(canBarrerini && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Barrerini());
        }

        if(canPowerini && Input.GetButtonDown("Fire3"))
        {
            StartCoroutine(Powerini());
        }

    }

    void SpawnBullet()
    {
        GameObject bullet = BulletPool.SharedInstance.GetBullet();
        if (bullet != null)
        {
            bullet.transform.position = transform.position + new Vector3(0, 0.5f, 0);
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().AddForce(bullet.GetComponent<Rigidbody2D>());
            StartCoroutine(bullet.GetComponent<Bullet>().GoBack());
        }
    }

    void SpawnAPBullet()
    {
        GameObject aPBullet = BulletPool.SharedInstance.GetAPBullet();
        if (aPBullet != null)
        {
            aPBullet.transform.position = transform.position + new Vector3(0, 0.5f, 0);
            aPBullet.SetActive(true);
            apBullet.GetComponent<Bullet>().AddForce(apBullet.GetComponent<Rigidbody2D>());
            StartCoroutine(apBullet.GetComponent<Bullet>().GoBack());
        }
    }

    private void OnDestroy()
    {
        StopCoroutine("FireCR");
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hazard>() != null)
        {
            Time.timeScale = 0F;
            print("Game Over");
        }
        if(collision.gameObject.CompareTag("Escudini"))
        {
            StartCoroutine(Escudini());
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator FireCR()
    {
        canFire = false;
        yield return new WaitForSeconds(coolDownTime);
        canFire = true;
    }

    private IEnumerator Barrerini()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        canBarrerini = false;
        yield return barreriniDuration;
        transform.GetChild(0).gameObject.SetActive(false);
        yield return cooldownBarrerini;
        canBarrerini = true;
    }

    private IEnumerator Escudini()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        yield return escudiniDuration;
        transform.GetChild(1).gameObject.SetActive(false);
    }

    IEnumerator Powerini()
    {
        canPowerini = false;
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 5, Vector2.zero);

        foreach (RaycastHit2D i in hits)
        {
            if (i.transform.gameObject.GetComponent<Hazard>() != null)
            {
                Destroy(i.transform.gameObject); 
            }
        }

        yield return poweriniCooldown;
        canPowerini = true;
    }

    
}