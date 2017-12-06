using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walldoor : MonoBehaviour {

    // Use this for initialization


    public bool open = false;
    //public bool close =true;
    public Transform target;


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


        Quaternion rot;
        if (open)
        {
            //var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 45.0f, 0.0f), Time.deltaTime * 200);
            var tr = target.rotation.eulerAngles + new Vector3(0.0f, 45.0f, 0.0f);
            var q =  Quaternion.Euler(tr);
            //Debug.Log("open: " + q);
            rot = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * 200);
        }
        else
        {


            // y on -5 koska ei mennyt suoraan 0 vaan meni kohti 5. 
            // var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, -5.0f, 0.0f), Time.deltaTime * 200 );
            //var q = Quaternion.Euler(0.0f, -5.0f, 0.0f);
            //Debug.Log("close: " + q);
            rot = Quaternion.RotateTowards(transform.rotation, target.rotation, Time.deltaTime * 200);
            //rot = Quaternion.RotateTowards(transform.rotation, new Quaternion(0,0,0,0), Time.deltaTime * 200);
            //transform.rotation = newRot;
        }
        transform.rotation = rot;
    }
}
