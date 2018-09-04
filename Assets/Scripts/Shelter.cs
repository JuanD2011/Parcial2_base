using UnityEngine;
using System.Collections;

public class Shelter : MonoBehaviour
{
    [SerializeField]
    private int maxResistance = 5;
    [SerializeField]
    private int resistance;

    public int MaxResistance
    {
        get
        {
            return maxResistance;
        }
        protected set
        {
            maxResistance = value;
        }
    }

    [SerializeField]
    float regenTime;

    private void Start()
    {
        resistance = maxResistance;
    }

    public void Damage(int damage)
    {
        resistance -= damage;
        StopAllCoroutines();
        if(resistance == 0)
        {
            ShelterDestroyed();
        }
        if(resistance != maxResistance)
        {
            StartCoroutine(ResistanceRegen());
        }
    }

    void ShelterDestroyed()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Hazard>() != null)
        {
            Damage(collision.gameObject.GetComponent<Hazard>().Damage);
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator ResistanceRegen()
    {
        Debug.Log(resistance);
        while(resistance < maxResistance)
        {
            yield return new WaitForSeconds(regenTime);
            resistance += 1;
            Debug.Log("+1");
        }
    }
}