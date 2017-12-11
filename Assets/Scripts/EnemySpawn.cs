using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 1f;            // How long between each spawn.
    public Transform spawnPoints;         // An array of the spawn points this enemy can spawn from.

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CancelInvoke("Spawn");
        }
    }

    void Spawn()
    {
            float spawnPointX = Random.Range(-500, 500);
            float spawnPointY = Random.Range(50, 300);
            float spawnPointZ = Random.Range(-500, 500);
            Vector3 spawnPosition = new Vector3(spawnPointX + spawnPoints.transform.position.x, spawnPointY + spawnPoints.transform.position.y, spawnPointZ + spawnPoints.transform.position.z);
            Instantiate(enemy, spawnPosition, enemy.transform.rotation);
    }
    
}

