using UnityEngine;
using UnityEngine.UI;

public class ScreenOutput : MonoBehaviour
{
    private Slot itemCount;
    public Text textItemCount;

    private void Start()
    {
        itemCount = gameObject.GetComponent<Slot>();
    }

    private void Update()
    {
        if (itemCount.itemsInSlot >= 2)
        {
            textItemCount.text = itemCount.itemsInSlot.ToString();
        }
        else
        {
            textItemCount.text = "";
        }
    }
}