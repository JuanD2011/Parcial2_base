using UnityEngine;

public class KillVolume : MonoBehaviour
{
    [SerializeField]
    private Shelter[] shelters;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hazard>() != null)
        {
            for (int i = 0; i < shelters.Length; i++)
            {
                if (shelters[i] != null)
                {
                    print("Damaging a shelter");
                }
            }
        }
        //Destroy(collision.gameObject);
        collision.gameObject.SetActive(false);
    }
}