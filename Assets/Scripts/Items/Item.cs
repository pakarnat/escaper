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
    public GameObject ItemGraphic;
    public bool isEquipped = false;
    private bool inInventory = false;

    public void PickedUp()
    {
        Collider collider = GetComponent<Collider>();
        Rigidbody rb = GetComponent<Rigidbody>();        
        collider.enabled = false;
        rb.useGravity = false;
        inInventory = true;
    }
    public void Equip()
    {
        isEquipped = true;
        ItemGraphic.GetComponent<MeshRenderer>().enabled = true;
        this.enabled = true;
    }
    public void UnEquip()
    {
        isEquipped = false;
        ItemGraphic.GetComponent<MeshRenderer>().enabled = false;
        this.enabled = false;
    }
    public bool InInventory()
    {
        return inInventory;
    }
}
