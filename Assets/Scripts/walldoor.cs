
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walldoor : MonoBehaviour {

    // Use this for initialization


    public bool open = false;
    //public bool close =true;
    public Transform target;
    


    void Update()    {
          

        Quaternion rot;
        if (open)
        {            
            Quaternion q = Quaternion.Euler(0, 45, 0);            
            rot = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * 20);
            


            
        }
        else
        {
            

            Quaternion q = Quaternion.Euler(0, 0, 0);
            rot = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * 20);
            
        }
        transform.rotation = rot;
    }
}
