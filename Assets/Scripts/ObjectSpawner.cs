using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject firstObjectPrefab;
    public int firstObjectNumber = 15;
    public GameObject secondObjectPrefab;
    public int secondObjectNumber = 15;

    public GameObject firstOtherPrefab;
    public GameObject secondOtherPrefab;
    public int otherObjectsNumber = 70;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float Normalize(float val, float min, float max)
    {
        return 0;
    }

    public void SpawnObjects()
    {
        for (int i=0; i<firstObjectNumber; i++)
        {
            float x = Random.Range(0, 100);
            float z = Random.Range(0, 100);
            Vector3 position = new Vector3(x, 0, z);
            GameObject myGameObject = Instantiate(firstObjectPrefab);
            myGameObject.transform.position = position;
        }

        for (int i=0; i<secondObjectNumber; i++)
        {
            float x = Random.Range(0, 100);
            float z = Random.Range(0, 100);
            Vector3 position = new Vector3(x, 0, z);
            GameObject myGameObject = Instantiate(secondObjectPrefab);
            myGameObject.transform.position = position;
        }

        for (int i=0; i<otherObjectsNumber; i++)
        {
            float x = Random.Range(0, 100);
            float z = Random.Range(0, 100);
            Vector3 position = new Vector3(x, 0, z);
            if (i < otherObjectsNumber*0.5f)
            {
                GameObject myGameObject = Instantiate(firstOtherPrefab);
                myGameObject.transform.position = position;
            }
            else
            {
                GameObject myGameObject = Instantiate(secondOtherPrefab);
                myGameObject.transform.position = position;
            }
        }
    }
}
