using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu(menuName:"GameItem")]
[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour {

    public string Name = "New Item";
    [Multiline(3)]
    public string Description = "Item Description";
    public Sprite Sprite;
    public GameObject GameObjectPrefab;

    public void isEquipped(bool inhand)
    {
        Collider collider = GetComponent<Collider>();
        Rigidbody rb = GetComponent<Rigidbody>();
        if (inhand)
        {
            collider.enabled = false;
            rb.useGravity = false;
        }
        else
        {
            collider.enabled = true;
            rb.useGravity = true;
        }
        
    }
}
