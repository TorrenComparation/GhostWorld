using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameObject player;
    private Inventory inventory;
    public GameObject slotButton;

    private float waittingSeconds = 2f;
    private bool canTake = false;



    private void Start()
    {
        StartCoroutine("CannotTake");
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canTake == true)
        {
            if (other.CompareTag("Player"))
            {
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.isFull[i] == true)
                    {
                        Transform slotTransform = inventory.slots[i].transform;
                        Transform itemTransform = slotTransform.childCount >= 2 ? slotTransform.GetChild(1) : null;
                       
                            if (itemTransform.name == gameObject.name && itemTransform != null)
                            {
                                ItemCounting count = itemTransform.GetComponent<ItemCounting>();
                                if (count != null)
                                {
                                    count.count += 1;
                                    Destroy(gameObject);
                                    break;
                                }
                            }
                        
                    }
                    else if (inventory.isFull[i] == false)
                    {
                        inventory.isFull[i] = true;
                        Instantiate(slotButton, inventory.slots[i].transform);
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }
    }

    private IEnumerator CannotTake()
    {
        yield return new WaitForSeconds(waittingSeconds);
        canTake = true;
    }
}

