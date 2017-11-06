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
    private bool isEquipped = false;
    private bool inInventory = false;

    public void PickedUp()
    {
        Collider collider = GetComponent<Collider>();
        Rigidbody rb = GetComponent<Rigidbody>();        
        collider.enabled = false;
        rb.useGravity = false;          
    }
    public void Equip()
    {
        isEquipped = true;
        this.GetComponent<MeshRenderer>().enabled = true;        
    }
    public void UnEquip()
    {
        isEquipped = false;
        this.GetComponent<MeshRenderer>().enabled = false;
    }
    public bool InInventory()
    {
        return inInventory;
    }
}
