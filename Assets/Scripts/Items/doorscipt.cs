using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorscipt : MonoBehaviour {

	// Use this for initialization
	

    public bool open;
    public bool close;
   


    void Update()
    {
            if (close)
            {
               
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        open = true;
                        close = false;
                    }
            
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    close = true;
                    open = false;
                }
            }
   

        if (open)
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 45.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
        }
        else
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 130.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
        }
    }
}
