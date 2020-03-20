using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JuicyObjectFinder : MonoBehaviour
{
    public ObjectSpawner objectSpawner;
    public GameObject particleSystem1;
    public GameObject particleSystem2;
    public MeshRenderer groundPlaneRenderer;
    public AudioSource foundAudio;
    public Text firstText;
    public Text secondText;

    public int firstObjectCounter;
    public int secondObjectCounter;

    public float step = 0.01f;
    public float maxValue = 20;
    public bool groundEffect;

    protected int totalNumberFirstObjects;
    protected int totalNumberSecondObjects;
    protected List<GameObject> foundObjects;

    public float groundValue = 0;


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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            groundEffect = true;
        }
        if (groundEffect)
        {
            groundValue += step;

            groundPlaneRenderer.material.SetFloat("Vector1_B8EE4FC3", groundValue);

            if (groundValue>maxValue)
            {
                groundValue = 0;
                groundPlaneRenderer.material.SetFloat("Vector1_B8EE4FC3", groundValue);
                groundEffect = false;
            }
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
            firstText.text = firstObjectCounter + "/" + totalNumberFirstObjects + " Objects found!";
            foundAudio.Play();
            GameObject prt1 = Instantiate(particleSystem1);
            prt1.transform.position = myObject.transform.position;
            prt1.GetComponent<ParticleSystem>().Play();
            groundPlaneRenderer.material.SetColor("Color_66D42137", Color.green);
            groundPlaneRenderer.material.SetVector("Vector3_9F72F952", myObject.transform.position);
            groundEffect = true;
        }
        else if (objectName.Contains("SecondObject"))
        {
            secondObjectCounter++;
            Destroy(myObject);
            secondText.text = secondObjectCounter + "/" + totalNumberSecondObjects + " Objects found!";
            foundAudio.Play();
            GameObject prt2 = Instantiate(particleSystem2);
            prt2.transform.position = myObject.transform.position;
            prt2.GetComponent<ParticleSystem>().Play();
            groundPlaneRenderer.material.SetColor("Color_66D42137", Color.red);
            groundPlaneRenderer.material.SetVector("Vector3_9F72F952", myObject.transform.position);
            groundEffect = true;
        }
        if (foundObjects.Contains(myObject))
        {
            foundObjects.Remove(myObject);
        }
    }
}
