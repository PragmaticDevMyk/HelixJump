using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;

    public GameObject lastRing;

    public float ySpawn = 0;

    public float ringDistance = 5;

    public int numberOfRings;

    // Start is called before the first frame update
    void Start()
    {
        numberOfRings =  GameManager.currentLevelIndex + 5;
        //spawn helix rings

        for(int i = 0; i < numberOfRings; i++) {
            if(i == 0)
            SpawnRings(0);
            else

            SpawnRings(Random.Range(1, helixRings.Length - 1));
        }

        //spawn last ring

        SpawnRings(helixRings.Length - 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRings(int ringIndex) {

        GameObject gameObject = Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity);
        gameObject.transform.parent = transform;
        ySpawn -= ringDistance;
    }
}
