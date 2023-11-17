using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{

    public Text Disable;
  


    private void Start()
    {
        Disable.text = "Disabled";
        Disable.color = Color.red;
      
    
    }


    public void ChangeColor()
    {
        Disable.text = "Enabled";
        Disable.color = Color.green;
    }






}
