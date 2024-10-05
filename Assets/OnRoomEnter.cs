using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRoomEnter : MonoBehaviour
{
    public bool roomStay = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
     if(other.gameObject.CompareTag("Room1"))
        {
            roomStay = true;
        }   
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Room1"))
        {
            roomStay = false;
        }
    }
}
