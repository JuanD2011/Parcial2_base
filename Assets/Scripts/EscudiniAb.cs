using System.Collections;
using UnityEngine;

public class EscudiniAb : MonoBehaviour
{
    private WaitForSeconds escudiniDuration = new WaitForSeconds(5);

    private void Start()
    {
        StartCoroutine(Escudini());
    }

    private IEnumerator Escudini()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        yield return escudiniDuration;
        transform.GetChild(1).gameObject.SetActive(false);
        Destroy(this);
    }
}
