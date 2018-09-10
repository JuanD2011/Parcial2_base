using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Text numOfHazard;
    int contador;

    private void Start()
    {
        Hazard.OnWriteDeaths += NumHazards;
    }

    private void NumHazards()
    {
        contador++;
        numOfHazard.text = contador.ToString() + " Num of hazards";
    }
}
