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
}
