using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDistanceMeter : MonoBehaviour
{
    public float minLength = 0;
    public float maxLength = 200;

    private RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(minLength, rect.sizeDelta.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLength(float val)
    {
        val = 1 - val;
        rect.sizeDelta = new Vector2((maxLength-minLength)*val, rect.sizeDelta.y);
    }
}
