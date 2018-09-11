using UnityEngine;

public static class SpawnerExtensions
{
    public static Vector3 GetPointInVolume(this Collider2D collider)
    {
        Vector3 result = Vector3.zero;
        result = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x), collider.transform.position.y, 0F);

        return result;
    }
}

[RequireComponent(typeof(Collider2D))]
public class HazardSpawner : MonoBehaviour
{
    //[SerializeField]
    //private GameObject[] hazardTemplates;

    private Collider2D myCollider;

    [SerializeField]
    private float spawnFrequency = 1F;

    // Use this for initialization
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();

        InvokeRepeating("SpawnEnemy", 0.2F, spawnFrequency);
    }

    private void SpawnEnemy()
    {
        int whichHazard = Random.Range(0, 4);
        GameObject hazard = HazardsPool.SharedInstance.GetHazard();

        if(hazard.GetComponent<Invader>() != null)
        {
            hazard.GetComponent<Invader>().MovementRadius = Random.Range(0.5f, 2);
        }

        if (hazard == null)
        {
            CancelInvoke();
        }
        else
        {
            if (hazard != null)
            {
                hazard.SetActive(true);
                hazard.transform.position = myCollider.GetPointInVolume();
            }
        }
    }
}