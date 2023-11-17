using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchIceSpike : MonoBehaviour
{

    private Vector3 targetPosition;
    private PlayerMoving playerStatistic;
    private float speed = 5f;

 
    void Start()
    {
        
        playerStatistic = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoving>();
        if (playerStatistic.isRight == true)
        {
            targetPosition = new Vector3(gameObject.transform.position.x + 5, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else
        {
            targetPosition = new Vector3(gameObject.transform.position.x - 5, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        
       
    }


    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, speed * Time.deltaTime);
        if(gameObject.transform.position == targetPosition)
        {
           Destroy(gameObject);
        }


    }
}
