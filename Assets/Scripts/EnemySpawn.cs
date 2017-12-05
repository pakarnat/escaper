using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 0.05f;            // How long between each spawn.
    public Transform spawnPoints;         // An array of the spawn points this enemy can spawn from.
    
    



        void Start()
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
           

        }
    private void OnTriggerEnter(Collider other)
    {
       InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
         
    void Spawn()
        {
            float spawnPointX = Random.Range(-500, 500);
            float spawnPointY = Random.Range(-100, 100);
            float spawnPointZ = Random.Range(-1000, 2000);
            Vector3 spawnPosition = new Vector3(spawnPointX + spawnPoints.transform.position.x, spawnPointY + spawnPoints.transform.position.y, spawnPointZ + spawnPoints.transform.position.z);
            // Find a random index between zero and one less than the number of spawn points.

            Instantiate(enemy, spawnPosition, enemy.transform.rotation);
        }
    
}

