using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarreriniAb : MonoBehaviour
{
    public static bool canBarrerini = true;
    private WaitForSeconds barreriniDuration = new WaitForSeconds(5);
    private WaitForSeconds cooldownBarrerini = new WaitForSeconds(5);

    private void Start()
    {
        StartCoroutine(Barrerini());
    }

    private IEnumerator Barrerini()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        canBarrerini = false;
        yield return barreriniDuration;
        transform.GetChild(0).gameObject.SetActive(false);
        yield return cooldownBarrerini;
        canBarrerini = true;
        Destroy(this);
    }
}
