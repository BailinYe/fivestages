using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private Transform shadowLocationLeft;
    private Transform shadowLocationRight;
    private float height = 20;
    private object thisObject;
    // Start is called before the first frame update
    void Start()
    {
        Awake();
    }

    public void Awake()
    {
        thisObject = GetComponent<Object>();
    }
    // Update is called once per frame
    void Update()
    {

    }


}
