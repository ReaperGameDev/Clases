using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{

    int vidaPersonaje = 50;
    int curacion;
    [SerializeField] int pocionID;
    private void Start()
    {
        CuracionPorPocion(pocionID);
        Debug.Log(vidaPersonaje);
    }

    void CuracionPorPocion(int nroPocion)
    {
        switch(nroPocion)
        {
            case 1:
                curacion = 20;
                break;
            case 2:
                curacion = 40;
                break;
            case 3:
                curacion = 60;
                break;
            case 4:
                curacion = 80;
                break;
        }
        vidaPersonaje += curacion;
    }
   
}



