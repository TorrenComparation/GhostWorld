using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingForName : MonoBehaviour
{
    private string addedString = "(Clone)";
    private int index;
    private float livingTime = 1f;

    private void Start()
    {
        index = gameObject.name.IndexOf(addedString);
        if (index == -1)
        {
            gameObject.name += addedString;
        }
    }
    
    private IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(livingTime);
        Destroy(gameObject.GetComponent<CheckingForName>());
    }
}
