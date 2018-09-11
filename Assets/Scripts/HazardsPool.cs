using System.Collections.Generic;
using UnityEngine;

public class HazardsPool : MonoBehaviour {

    public static HazardsPool SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }

    [SerializeField]
    int hazards;

    List<GameObject> hazardsPool; 
    [SerializeField] GameObject template;
    Vector3 spawnPos = new Vector3(12, 0, 0);

    private void Start()
    {
        hazardsPool = new List<GameObject>();

        for (int i = 0; i < hazards; i++)
        {
            GameObject hazardClone = Instantiate(template);//Cloning it the times we specified
            hazardClone.AddComponent(typeof(Hazard));
            hazardClone.layer = 8;
            GameObject debrisClone = Instantiate(template);//Cloning it the times we specified
            debrisClone.AddComponent(typeof(Debris));
            debrisClone.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(0,0,255);
            GameObject invaderClone = Instantiate(template);//Cloning it the times we specified
            invaderClone.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(255, 0, 0);
            invaderClone.AddComponent(typeof(Invader));
            ResetHazard(hazardClone);
            ResetHazard(debrisClone);
            ResetHazard(invaderClone);
            hazardsPool.Add(hazardClone);//Adding it to the list
            hazardsPool.Add(debrisClone);//Adding it to the list
            hazardsPool.Add(invaderClone);//Adding it to the list
        }
    }

    public GameObject GetHazard()
    {
        for (int i = 0; i < hazardsPool.Count; i++)//Loop to iterate throught the list
        {
            if (!hazardsPool[i].activeInHierarchy)//Check if the item is NOT currently active in the scene
            { 
                return hazardsPool[i];//If it is, the loop moves to the next position and returns the object
            }
        }
        return null;//If there is not inactive objects, exit the method and returns nothing
    }

    public void ResetHazard(GameObject _hazard)
    {
        _hazard.SetActive(false);
        _hazard.transform.position = spawnPos;
        _hazard.GetComponent<Hazard>().Resistance = 1;
        if (_hazard.GetComponent<Invader>() != null)
        {
            _hazard.GetComponent<Collider2D>().enabled = true;
            _hazard.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            _hazard.GetComponent<Invader>().Dead = false;
        }
    }
}
