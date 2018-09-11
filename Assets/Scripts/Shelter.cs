using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shelter : MonoBehaviour
{
    [SerializeField]
    private int maxResistance = 5;

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

    WaitForSeconds regenTime = new WaitForSeconds(10);

    [SerializeField]
    Text text;

    private void Start()
    {
        resistance = maxResistance;
        text.text = resistance.ToString();
    }

    public void Damage(int damage)
    {
        StopAllCoroutines();
        resistance -= damage;
        text.text = resistance.ToString();
        StartCoroutine(ResistanceRegen());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Hazard>() != null)
        {
            Damage(collision.gameObject.GetComponent<Hazard>().Damage);
        }
    }

    IEnumerator ResistanceRegen()
    {
        while(resistance < maxResistance)
        {
            yield return regenTime;
            resistance++;
            text.text = resistance.ToString();
        }
    }
}