using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using System.Linq.Expressions;

public class Inventory : MonoBehaviour
{

    public List<string> items = new List<string>();


    public void AddToInventory(string itemName)
    {
        items.Add(itemName);
    }

    public void RemoveFromInventory(string itemName)
    {
        items.Remove(itemName);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            AddToInventory("Test item");
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            RemoveFromInventory("Test item");
        }
    }
}
