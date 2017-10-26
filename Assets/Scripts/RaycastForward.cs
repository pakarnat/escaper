using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastForward : MonoBehaviour {

    [SerializeField]
    private InventoryDetails _inventoryDetails;


    // Update is called once per frame
    void Update () {
        RaycastHit hit;
        float rayDistance;
        int layerMask = LayerMask.GetMask("Item");

        //Debug
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.yellow);

        if(Physics.Raycast(transform.position, forward, out hit, 10, layerMask))
        {
            Item item = hit.collider.gameObject.GetComponent<Item>();           
            
            rayDistance = hit.distance;
            Debug.Log(rayDistance + " " + item.Name);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Item item = hit.collider.gameObject.GetComponent<Item>();
            PickUpItem(item);
            Destroy(hit.collider.gameObject);
            Debug.Log("Fire1");
        }
    }

    public void PickUpItem(Item item)
    {
        _inventoryDetails.InventoryItems.Add(item);       
    }
}
