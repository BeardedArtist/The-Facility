using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    [SerializeField] public bool hasRedKey = false;

    private void Awake() 
    {
        Instance = this;
    }

    private void Update() 
    {
        checkForItem();    
    }

    private void checkForItem() 
    {
        for (int I = 0; I < Items.Count; I++)
        {
            if (Items[I].itemName == "RedKey")
            {
                hasRedKey = true;
            }
        } 
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }
}
