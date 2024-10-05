using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public GameObject spawnPoint1;
    public GameObject spawnPoint2;

    bool checkPoint1Activated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            if (checkPoint1Activated)
            {
                this.transform.position = spawnPoint2.transform.position;
            }
            else
            {
                this.transform.position = spawnPoint1.transform.position;
            }
           
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "CheckPoint1")
        {
            Debug.Log("Funciona");
            checkPoint1Activated = true;
        }
    }
}
