
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walldoor : MonoBehaviour {

    // Use this for initialization


    public bool open = false;
    //public bool close =true;
    public Transform target;
    public AudioClip ovi_auki;
    
    public AudioSource source;
    public bool hasplayed = false;
    public bool hasplayed1 = false;
    void Awake()
    {

        source = GetComponent<AudioSource>();

    }


    void Update()    {
          

        Quaternion rot;
        if (open)
        {            
            Quaternion q = Quaternion.Euler(0, 45, 0);            
            rot = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * 20);
            if (!source.isPlaying && hasplayed == false)
            {
                source.Play();
               // Debug.Log("OVI AUKI");
                hasplayed = true;
            }


            hasplayed1 = false;
        }
        else
        {
            hasplayed = false;//jotta toimii uudelleen

            if (!source.isPlaying && hasplayed1 == false)
            {
                source.Play();
                // Debug.Log("OVI AUKI");
                hasplayed1 = true;
            }

            Quaternion q = Quaternion.Euler(0, 0, 0);
            rot = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * 20);
            
        }
        transform.rotation = rot;
    }
}
