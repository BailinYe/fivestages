using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public Transform left;
    public Transform right;
    public float groundHeight = 200;
    private float movedDistance;
    public float shouldMovedDistance = 10;
    public float floatSpeed = 2.5F;
    public PolygonCollider2D shawdowCollider;
    public MeshFilter shadowMesh;
    private float timer = 0;
    public float safeTime = 2;
    public Sun sun;
    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cloudPosition = Vector2.zero; //new Vector2(transform.position.x , transform.position.y);

        Vector2 cloudLeft = getCloudLeft();
        Vector2 cloudRight = getCloudRight();
        Vector2 groundLeft = getPointOnGround(sun.getLightResource(), cloudLeft);
        Vector2 groundRight = getPointOnGround(sun.getLightResource(), cloudRight);
        Vector2[] shadowPoints = { groundLeft - cloudPosition, groundRight - cloudPosition, cloudRight - cloudPosition, cloudLeft - cloudPosition };
        shawdowCollider.SetPath(0, shadowPoints);

        timer += Time.deltaTime;
        if(timer < 5) { //the safe period for player to move around
            shadowMesh.mesh = shawdowCollider.CreateMesh(false, false);
        }
        else
        {
            shadowMesh.mesh = null;
            if(timer > 5 + safeTime) { 
                timer = 0;
            }
        }

        if (movedDistance < shouldMovedDistance)
        {
            this.transform.transform.position = transform.position + (Vector3.left * floatSpeed * Time.deltaTime);
        }
        else
        {
            this.transform.transform.position = transform.position + (Vector3.right * floatSpeed * Time.deltaTime);
            if (movedDistance > 2*shouldMovedDistance)
            {
                movedDistance = 0;
            }
        }
        movedDistance += floatSpeed * Time.deltaTime;
    }

    Vector2 getCloudLeft()
    {
        return (new Vector2(left.position.x, left.position.y));
    }

    Vector2 getCloudRight()
    {
        return (new Vector2(right.position.x, right.position.y));
    }

    Vector2 getPointOnGround(Vector2 sunLightSource, Vector2 cloudEdge)
    {
        Vector2 lightDirec = sunLightSource - cloudEdge;
        float cloudToGroundY = groundHeight - cloudEdge.y;
        //lightDirec.Normalize();
        float coefficient;
        float y;
        float a;
        float b;
        coefficient = sunLightSource.x - cloudEdge.x;
        y = sunLightSource.y - cloudEdge.y;
        a = y / coefficient; //
        b = sunLightSource.y - coefficient * a;
        float cloudToGroundX = cloudToGroundY / a;
        return (new Vector2(cloudToGroundX + cloudEdge.x, groundHeight));
        //return (new Vector2(-b / a, 0));
    }

}
