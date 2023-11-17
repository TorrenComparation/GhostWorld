using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   
        public int EnterDamage = 10;
        public string collisionTag;


    private void OnCollisionEnter2D(Collision2D other) 
    {
      if(other.gameObject.tag == collisionTag)
      {
        PlayerStatistic heath = other.gameObject.GetComponent<PlayerStatistic>();
        heath.TakeHit(EnterDamage);
      }
    }

    


    
}
