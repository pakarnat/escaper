using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryDetails : MonoBehaviour{

    public List<GameObject> InventoryItems;
    public int totalSlots = 10;

    public GameObject GetItem(string name)
    {
        foreach (GameObject item in InventoryItems)
        {
           if(item.GetComponent<Item>().Name == name)
            {
                return item;
            }            
        }
        return null;
    }

}
