using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Inventory : MonoBehaviour
{
    
    public List<Collectable> inventory = new List<Collectable>();
    public List<GameObject> inventoryUI = new List<GameObject>();  
    private Transform player;
    [SerializeField] private GameObject itemSlotTemplate; 
    [SerializeField] private GameObject container; 

    private void Start() { 
        player = GameObject.Find("Player").GetComponent<Transform>(); 
    }

    private void OnEnable() { 
        Collectable.ItemPickup += AddItem;  
    }

    private void OnDisable() {
        Collectable.ItemPickup -= AddItem; 
    }

    public void AddItem(Collectable _item) { 
        inventory.Add(_item);
        _item.transform.SetParent(player);
        GameObject newContainer = Instantiate(itemSlotTemplate,
                                              container.transform.position + new Vector3((100 * inventoryUI.Count),0,0),
                                              container.transform.rotation,
                                              container.transform);
        inventoryUI.Add(newContainer);

        newContainer.transform.GetChild(1).GetComponent<Image>().sprite = _item.prefab.GetComponent<SpriteRenderer>().sprite;
        newContainer.SetActive(true);   
    }
    
    public void drop() {
        if (inventory.Count > 0) { 
            Collectable itemToDrop = inventory[inventory.Count-1];
            itemToDrop.transform.position = player.position + new Vector3(-2f,0f,0f);
            itemToDrop.gameObject.SetActive(true);
            itemToDrop.transform.SetParent(null); 
            inventory.RemoveAt(inventory.Count-1);
            
            GameObject removeObj = inventoryUI[inventoryUI.Count-1];
            inventoryUI.RemoveAt(inventoryUI.Count-1);
            Destroy(removeObj);
            }
    }

    public void useLastItem() {
        if (inventory.Count > 0) {
            Collectable lastItem = inventory[inventory.Count-1];
            lastItem.Use();
            inventory.RemoveAt(inventory.Count-1);
            Destroy(lastItem);

            GameObject removeObj = inventoryUI[inventoryUI.Count-1];
            inventoryUI.RemoveAt(inventoryUI.Count-1);
            Destroy(removeObj); 
        }
    }

    public List<Collectable> GetItemList() {
        return inventory; 
    }
}
