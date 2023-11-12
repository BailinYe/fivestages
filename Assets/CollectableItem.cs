using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    private Collider2D collisionArea;
    private bool shouldRespawn = false;
    public float timer = 0;
    public float respawnTime = 1F;
    private Vector3 currentPos;
    public GameObject collectableItem; //the prefab you want to spawn
    private Object thisObject;

    //public GameObject ; //the prefab you want to spawn
    private GameObject spawnedball; //a local temporary reference


    public void Awake()
    {
        thisObject = GetComponent<Object>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldRespawn)
        {
            timer += Time.deltaTime;
            if(timer > respawnTime)
            {
                //thisObject = new CollectableItem(); //or set multiple boolean variables for more items
                //this.transform.position = new Vector3(2, 20, 0);
                
                Vector3 newPos = new Vector3(currentPos.x - 5, currentPos.y, 0);
                //GameObject collectableItem = Instantiate(collectableItem, newPos, Quaternion.identity);
                //collectableItem = (GameObject)Instantiate(collectableItem, newPos, new Quaternion());
                //gameObject.transform.SetPositionAndRotation(gameObject.transform.position.x) -= 5;
                //Vector3 newPos = new Vector3(gameObject.transform.position.x - 5, gameObject.transform.position.y, gameObject.transform.position.z);
                //gameObject.transform.position = newPos;
                //gameObject.SetActive(true);
                shouldRespawn = false;
                timer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //need set the player with PlayerCollider tag to make it work
        {
            shouldRespawn = true;
            //Vector3 newPos = new Vector3(gameObject.transform.position.x - 5, gameObject.transform.position.y, 0);
            //gameObject.transform.position = newPos;
            currentPos = transform.position;
            Vector3 newPos = new Vector3(currentPos.x - 5, currentPos.y, currentPos.z);
            this.transform.position = newPos;
            //Destroy(gameObject);
            //gameObject.SetActive(false); // Unity will no longer call Update() method
        }
    }
}
