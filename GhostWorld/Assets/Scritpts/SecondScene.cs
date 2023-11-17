using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondScene : MonoBehaviour
{
    public GameObject Circle;
    private bool isActive;

    private void Start()
    {
        if(isActive == false)
        {
            Circle.SetActive(true);
            isActive = true;
        }
      
        StartCoroutine(ITimer());
    }

    private IEnumerator ITimer()
    {
        yield return new WaitForSeconds(0.6f);
        Circle.SetActive(false);
        isActive = false;
    }
}
