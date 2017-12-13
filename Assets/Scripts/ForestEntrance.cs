using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestEntrance : MonoBehaviour {

    public GameObject Player;
    public MeshCollider invWall;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {            
            Destroy(invWall);
            Debug.Log("I can't go there, it's too dark.");
        }
        
    }


}
