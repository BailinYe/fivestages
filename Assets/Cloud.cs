using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public Transform left;
    public Transform right;
    public Sun sun;
    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector2 getCloudLeft()
    {
        return (new Vector2(left.position.x, left.position.y));
    }

    Vector2 getCloudRigth()
    {
        return (new Vector2(right.position.x, right.position.y));
    }

}
