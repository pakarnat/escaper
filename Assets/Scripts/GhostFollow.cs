using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFollow : MonoBehaviour {

   
    public int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 5;



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
        
    }

}
