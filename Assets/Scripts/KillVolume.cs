using UnityEngine;

public class KillVolume : MonoBehaviour
{
    public delegate void GameOver();
    public static event GameOver OnGameOver;

    [SerializeField]
    private Shelter[] shelters;
    private bool gameOver;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hazard>() != null)
        {
            for (int i = 0; i < shelters.Length; i++)
            {
                if (shelters[i] != null)
                {
                    gameOver = false;    
                }
                else
                {
                    gameOver = true;
                }
            }
        }
        if(gameOver)
        {
            OnGameOver();
            Time.timeScale = 0.01f;
        }

        Destroy(collision.gameObject);
    }
}