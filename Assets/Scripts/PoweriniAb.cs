using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweriniAb : MonoBehaviour
{
    private WaitForSeconds poweriniCooldown = new WaitForSeconds(10);
    public static bool canPowerini = true;

    private void Start()
    {
        StartCoroutine(Powerini());
    }

    IEnumerator Powerini()
    {
        canPowerini = false;
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 5, Vector2.zero);

        foreach (RaycastHit2D i in hits)
        {
            if (i.transform.gameObject.GetComponent<Hazard>() != null)
            {
                HazardsPool.SharedInstance.ResetHazard(i.transform.gameObject);
            }
        }

        yield return poweriniCooldown;
        canPowerini = true;
        Destroy(this);
    }
}
