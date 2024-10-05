using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    int nota = 60;
    
    void Start()
    {
        if (nota >= 90)
        {
            Debug.Log("Excelente");
        }
        else if(nota >= 80)
        {
            Debug.Log("Promedio");
        }
        else if (nota >= 70)
        {
            Debug.Log("Mejorable");
        }
        else if (nota >= 60)
        {
           // Debug.Log("Aprobado");
        }
        else
        {
            Debug.Log("Desaprobado");
        }

    }

}
