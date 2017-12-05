using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauttakiinniPelaajaan : MonoBehaviour {
    public GameObject player;
    public Transform platform;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("osuma");
            player.transform.SetParent(platform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player.transform.parent = null;
    }
}
