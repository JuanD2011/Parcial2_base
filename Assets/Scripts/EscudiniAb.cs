using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudiniAb : MonoBehaviour
{

    private WaitForSeconds escudiniDuration = new WaitForSeconds(5);

    private IEnumerator Escudini()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        yield return escudiniDuration;
        transform.GetChild(1).gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Escudini"))
        {
            StartCoroutine(Escudini());
            Destroy(collision.gameObject);
        }
    }
}
