using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarreriniAb : MonoBehaviour
{
    private bool canBarrerini = true;
    private WaitForSeconds barreriniDuration = new WaitForSeconds(5);
    private WaitForSeconds cooldownBarrerini = new WaitForSeconds(5);

	void Update ()
    {
        if (canBarrerini && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Barrerini());
        }
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
}
