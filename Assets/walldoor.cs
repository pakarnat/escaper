using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walldoor : MonoBehaviour {

    // Use this for initialization


    public bool open = false;
    //public bool close =true;



    void Update()
    {
        //if (close)
        //{

        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        open = true;
        //        close = false;
        //    }

        //}
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        close = true;
        //        open = false;
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.E))
        {
            //close = !close;
            open = !open;
        }



        if (open)
        {
            //var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 45.0f, 0.0f), Time.deltaTime * 200);
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 45.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
        }
        else
        {


            // y on -5 koska ei mennyt suoraan 0 vaan meni kohti 5. 
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, -5.0f, 0.0f), Time.deltaTime * 200 );
            transform.rotation = newRot;
        }
    }
}
