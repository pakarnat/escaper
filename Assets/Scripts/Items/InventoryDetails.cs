using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Inventory", fileName = "Inventory Data")]
public class InventoryDetails : ScriptableObject {

    public List<Item> InventoryItems;
    [Range(5,50)]
    public int TotalSlots;

}
