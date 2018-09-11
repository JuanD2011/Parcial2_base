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
    [SerializeField] GameObject hazard;
    [SerializeField] GameObject debri;
    [SerializeField] GameObject invader;
    [SerializeField] GameObject powerUp;

    private void Start()
    {
        hazardsPool = new List<GameObject>();

        for (int i = 0; i < hazards; i++)
        {
            GameObject hazardClone = Instantiate(hazard);//Cloning it the times we specified
            GameObject debrisClone = Instantiate(debri);//Cloning it the times we specified
            GameObject invaderClone = Instantiate(invader);//Cloning it the times we specified
            GameObject powerUpClone = Instantiate(powerUp);
            hazardClone.SetActive(false);//Seting it inactive
            debrisClone.SetActive(false);
            invaderClone.SetActive(false);
            powerUpClone.SetActive(false);
            hazardsPool.Add(hazardClone);//Adding it to the list
            hazardsPool.Add(debrisClone);//Adding it to the list
            hazardsPool.Add(invaderClone);//Adding it to the list
            hazardsPool.Add(powerUpClone);
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
}
