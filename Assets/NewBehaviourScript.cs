using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public List<int> vidaEnemigosLista = new List<int>();
    public int[] vidaEnemigos = new int[10];

    // Start is called before the first frame update

    void Start()
    {
        for (int i = 0; vidaEnemigos.Length > i; i++) 
        { 
            vidaEnemigos[i] = 100;
        }

        for (int i = 0; 10 > i; i++)
        {
            vidaEnemigosLista.Add(i);
            Debug.Log(vidaEnemigosLista[i]);
            vidaEnemigosLista.RemoveAt(3);
        }
    }


}
