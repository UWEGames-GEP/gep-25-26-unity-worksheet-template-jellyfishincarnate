using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using System.Linq.Expressions;

public class Inventory : MonoBehaviour
{

    //public List<string> items = new List<string>();
    public List<ItemObject> items = new List<ItemObject>();

    private GameManager gameManager;
    private Transform worldItemsTransform;
   

    public void AddToInventory(ItemObject item)
    {
        items.Add(item);
    }

    public void RemoveItemFromInventory(ItemObject item)
    {
        if (gameManager.state == GameState.GAMEPLAY && items.Count > 0)
        {
            ItemObject item = items[0];

            Vector3 currentPosition = transform.position;
            Vector3 forward = transform.forward;

            Vector3 newPosition = currentPosition + forward;
            newPosition += new Vector3(0, 1, 0);

            Quaternion currentRotation = transform.rotation;
            Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 180);

            GameObject newItem = Instantiate(item.gameObject, newPosition, newRotation, worldItemsTransform);
            newItem.SetActive(true);

            items.Remove(item);
            Destroy(item.gameObject);

        }
        
        
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        Transform worldItemsTransform = GameObject.find("WorldItems").transform;

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

        ItemObject collisionItem = hit.gameObject.GetComponent<ItemObject>();
        if(collisionItem != null)
        {
            items.Add(collisionItem);
            collisionItem.gameObject.SetActive(false);
        }


        // Items collisionItem = hit.gameObject.GetComponent<Items>();
        //if (collisionItem != null)
       // {
       //     items.Add(collisionItem.name);
       //     Destroy(collisionItem.gameObject);
       // }
   }
}
