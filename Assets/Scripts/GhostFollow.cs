using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFollow : MonoBehaviour {

   
    public int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 5;

    [SerializeField]
    private float health = 10;



    void Start()
    {
        
    }

    void Update()
    {
        
        Transform Player = GameObject.FindWithTag("Player").transform;
        transform.LookAt(Player);
        //transform.rotation = new Quaternion(90, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }

        }
        if(this.health <= 0)
        {
            this.gameObject.GetComponent<Collider>().enabled = false;
            Die();
        }
        
    }

    

    private void Die()
    {
        this.gameObject.GetComponent<ParticleSystem>().Play();
        Destroy(this.gameObject, 2);
        Debug.Log("Enemy Died!");
    }

    public void TakeDamage()
    {
        this.health--;
    }

}
