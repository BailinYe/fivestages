using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sun : MonoBehaviour
{
    public Transform lightSource;
    private Vector2 midPoint ;
    private object thisObject;
    private float movedDistance;
    private float floatSpeed = 2.5F;
    // Start is called before the first frame update

    public void Awake()
    {
        thisObject = GetComponent<Object>();
    }

    void Start()
    {
        Awake();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(movedDistance < 10) { 
        //    this.transform.transform.position = transform.position + (Vector3.left * floatSpeed * Time.deltaTime);
        //}
        //else
        //{
        //    this.transform.transform.position = transform.position + (Vector3.right * floatSpeed * Time.deltaTime);
        //    if (movedDistance > 20)
        //    {
        //        movedDistance = 0;
        //    }
        //}
        //movedDistance += floatSpeed * Time.deltaTime;
        //gameObject.GetComponent<Rigidbody>().useGravity = false;

    }

    public Vector2 getLightResource()
    {

        return (new Vector2(lightSource.position.x, lightSource.position.y));
    } 
}
