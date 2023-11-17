using UnityEngine;

public class SwitchSlot : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotFrame;
    public GameObject[] slots;
    public GameObject[] activeSlots;
    public bool[] isActiveSlots;

    private void Start()
    {
        inventory = GetComponent<Inventory>();

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            slots[i] = inventory.slots[i];
        }

        isActiveSlots = new bool[slots.Length];
    }
    private void Update()
    {
        for (int i = 0; i < activeSlots.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) && i < activeSlots.Length)
            {
                OffAllFrames();
                activeSlots[i].SetActive(true);
                isActiveSlots[i] = true;
            }
        }
    }

    private void OffAllFrames()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Transform slotTransform = slots[i].transform;
            Transform slotFrame = slotTransform.Find("slotFrame");

            if (slotFrame != null)
            {
                slotFrame.gameObject.SetActive(false);
                isActiveSlots[i] = false;
            }
        }
    }
}
