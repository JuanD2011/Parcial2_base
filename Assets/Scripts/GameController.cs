using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{ 
    [SerializeField] Text numOfHazard;
    int contador;

    private void Start()
    {
        Hazard.OnWriteDeaths += NumHazards;
        KillVolume.OnGameOver += GameOver;
        Shelter.OnGameOver += GameOver;
        PlayerController.OnGameOver += GameOver;
    }

    private void NumHazards()
    {
        contador++;
        numOfHazard.text = contador.ToString() + " Num of hazards";
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        Debug.Log("LOOSER");
    }
}
