using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyStatus : MonoBehaviour
{
    EnemyAI enemyScript;
    private void Start()
    {
        enemyScript = GameObject.FindObjectOfType<EnemyAI>(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyScript.activateEnemy = true;
        }
    }
}
