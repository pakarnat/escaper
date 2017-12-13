using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject enemy;                // Vihollisen Prefab
    public float spawnTime = 5f;            // Mitenkä pitkä väli vihollisien spawnien välissä.
    public Transform spawnPoints;         // Mistä kohteesta viholliset spawnaavat.
    AudioSource thunder;
    public static int killedEnemies = 0;
    public Light sun;

    void Start()
    {
        thunder = GetComponent<AudioSource>();
    }

    //kun pelaaja tulee (emptygameobject with trigger) alueelle jolle on määritetty koko niin, looppi käynnistyy joka kutsuu Spawn functiota ensimmäisen kerran spawnTime arvon mukaan.
    //ja tekee loopin joka kutsuu Spawn funktiota spawnTime arvon välein
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
          
            thunder.Play();
            InvokeRepeating("Spawn", spawnTime, spawnTime);
         
        }
    }
    //kun pelaa poistuu alueelta niin scripti lopettaa Spawn funktion kutsun.
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CancelInvoke("Spawn");
            CancelInvoke("valopaalle");
            CancelInvoke("valopois");
        }
    }
    void valopaalle()
    {
        sun.intensity = 1f;
    }
    void valopois()
    {
        sun.intensity = 0f;
    }

    void Spawn()
    {
        InvokeRepeating("valopaalle", 0, spawnTime);
        InvokeRepeating("valopois", 0.05f, spawnTime);
        float spawnPointX = Random.Range(-500, 500); // random x arvo
        float spawnPointY = Random.Range(50, 300); // random y arvo
        float spawnPointZ = Random.Range(-500, 500); //random z arvo
                                                     //spawnPosition arvo on spawnPoints sen hetkinen arvo plus sattuman varainen arvon lisäys yläpuolella olevien random muuttujien arvon mukaan
        Vector3 spawnPosition = new Vector3(spawnPointX + spawnPoints.transform.position.x, spawnPointY + spawnPoints.transform.position.y, spawnPointZ + spawnPoints.transform.position.z);
        Instantiate(enemy, spawnPosition, enemy.transform.rotation); // spawnataan uusi vihollinen spawnPosition arvoon   
        
    }  
    
}

