using System;
using UnityEngine;

public class MiniMapWithStatues : MonoBehaviour
{

    public GameObject map;
  [NonSerialized]  public bool hasMapOpen = false;

    private void Start()
    {
       
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) && hasMapOpen == false)
        {
            map.SetActive(true);
            hasMapOpen = true;
        }
        else if(Input.GetKeyDown(KeyCode.M) && hasMapOpen == true)
        {
            hasMapOpen = false;
            map.SetActive(false);
        }
        
    }
}
