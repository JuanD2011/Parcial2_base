using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour {

    public static BulletPool SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }

    [SerializeField]
    int bullets;
    List<GameObject> bulletsPool; //Bullets Pool
    [SerializeField] GameObject bullet;

    [SerializeField]
    int aPBullets;
    List<GameObject> aPBulletsPool; //APBullets Pool
    [SerializeField] GameObject aPBullet;

    void Start()
    {
        bulletsPool = new List<GameObject>();
        aPBulletsPool = new List<GameObject>();

        for (int i = 0; i < bullets; i++)
        {
            GameObject bulletsClone = Instantiate(bullet);//Cloning it the times we specified
            bulletsClone.SetActive(false);//Seting it inactive
            bulletsPool.Add(bulletsClone);//Adding it to the list
        }

        for (int i = 0; i < aPBullets; i++)
        {
            GameObject aPBulletsClone = Instantiate(aPBullet);//Cloning it the times we specified
            aPBulletsClone.SetActive(false);//Seting it inactive
            aPBulletsPool.Add(aPBulletsClone);//Adding it to the list
        }
    }

    public GameObject GetBullet()
    {
        for (int i = 0; i < bulletsPool.Count; i++)//Loop to iterate throught the list
        {
            if (!bulletsPool[i].activeInHierarchy)//Check if the item is NOT currently active in the scene
            {
                return bulletsPool[i];//If it is, the loop moves to the next position and returns the object
            }
        }
        return null;//If there is not inactive objects, exit the method and returns nothing
    }

    public GameObject GetAPBullet()
    {
        for (int i = 0; i < aPBulletsPool.Count; i++)//Loop to iterate throught the list
        {
            if (!aPBulletsPool[i].activeInHierarchy)//Check if the item is NOT currently active in the scene
            {
                return aPBulletsPool[i];//If it is, the loop moves to the next position and returns the object
            }
        }
        return null;//If there is not inactive objects, exit the method and returns nothing
    }
}
