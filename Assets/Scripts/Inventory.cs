using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using System.Linq.Expressions;

public class Inventory : MonoBehaviour
{

    public List<string> items = new List<string>();
    private GameManager gameManager;
   

    public void AddToInventory(string itemName)
    {
        items.Add(itemName);
    }

    public void RemoveItemFromInventory(string itemName)
    {
        items.Remove(itemName);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            AddToInventory("Test item");
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            RemoveItemFromInventory("Test item");
        }
    }

  private void OnControllerColliderHit(ControllerColliderHit hit)
  {
         Items collisionItem = hit.gameObject.GetComponent<Items>();
        if (collisionItem != null)
        {
            items.Add(collisionItem.name);
            Destroy(collisionItem.gameObject);
        }
   }
}
