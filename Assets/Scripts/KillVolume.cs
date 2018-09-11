using UnityEngine;

public class KillVolume : MonoBehaviour
{
    public delegate void GameOver();
    public static event GameOver OnGameOver;

    [SerializeField]
    private Shelter[] shelters;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hazard>() != null)
        {
            HazardsPool.SharedInstance.ResetHazard(collision.gameObject);
            OnGameOver();
        }
    }
}