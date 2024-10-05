using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<string> input = new List<string>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            input.Add("Escape");
        }
    }



}
