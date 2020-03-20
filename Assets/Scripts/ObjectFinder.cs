using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectFinder : MonoBehaviour
{
    public ObjectSpawner objectSpawner;
    public ObjectDistanceMeter firstMeter;
    public ObjectDistanceMeter secondMeter;
    public Text firstText;
    public Text secondText;

    public int firstObjectCounter;
    public int secondObjectCounter;

    protected int totalNumberFirstObjects;
    protected int totalNumberSecondObjects;
    protected List<GameObject> foundObjects;

    // Start is called before the first frame update
    void Start()
    {
        totalNumberFirstObjects = objectSpawner.firstObjectNumber;
        totalNumberSecondObjects = objectSpawner.secondObjectNumber;
        foundObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (foundObjects.Count > 0)
        {
            GameObject closestObject = foundObjects[0];
            float distance = Vector3.Distance(closestObject.transform.position, transform.position);
            float normalizedDistance = Normalize(distance, 0, 10);
            if (closestObject.name.Contains("FirstObject"))
            {
                firstMeter.SetLength(normalizedDistance);
            }
            else if (closestObject.name.Contains("SecondObject"))
            {
                secondMeter.SetLength(normalizedDistance);
            }
            print(normalizedDistance);
        }
    }

    public float Normalize(float val, float min, float max)
    {
        float result = (val - min) / (max - min);
        return result;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!foundObjects.Contains(other.gameObject))
        {
            foundObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (foundObjects.Contains(other.gameObject))
        {
            foundObjects.Remove(other.gameObject);
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        GameObject myObject = collision.gameObject;
        string objectName = myObject.name;
        if (objectName.Contains("FirstObject"))
        {
            firstObjectCounter++;
            Destroy(myObject);
            firstMeter.SetLength(0);
            firstText.text = firstObjectCounter + "/" + totalNumberFirstObjects + " Objects found!";
        }
        else if (objectName.Contains("SecondObject"))
        {
            secondObjectCounter++;
            Destroy(myObject);
            secondMeter.SetLength(0);
            secondText.text = secondObjectCounter + "/" + totalNumberSecondObjects + " Objects found!";
        }
        if (foundObjects.Contains(myObject))
        {
            foundObjects.Remove(myObject);
        }
    }
}
