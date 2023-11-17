using UnityEngine;

public class Slot : MonoBehaviour
{
    private Transform maker;
    private GameObject player;
    private Inventory inventory;
    private SwitchSlot materials;
    private Transform child;
    private ItemCounting inventoryCount;

    public string objectName;
    public int itemsInSlot;
    public int i;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>();
        materials = player.GetComponent<SwitchSlot>();
        inventoryCount = GetComponent<ItemCounting>();
    }
    private void Update()
    {

        if (transform.childCount == 2)
        {
            if (maker == null)
            {
                maker = gameObject.transform.GetChild(1);
                inventoryCount = maker.GetComponent<ItemCounting>();
            }
            itemsInSlot = inventoryCount.count;
            child = transform.GetChild(1);
            objectName = child.name;
            if (Input.GetKeyDown(KeyCode.Q) && i >= 0 && i <= 5 && materials.isActiveSlots[i] == true)
            {
                DropItem();
            }
        }

        if (transform.childCount <= 1)
        {
            inventory.isFull[i] = false;
        }
    }
    public void DropItem()
    {
        if (child != null)
        {
            inventoryCount.count -= 1;
            Drop dropComponent = child.GetComponent<Drop>();
            if (dropComponent != null)
            {
                dropComponent.SpawnDroppedItem();
            }

            if (inventoryCount.count == 0)
            {
                GameObject.Destroy(child.gameObject);
            }

        }
    }
}