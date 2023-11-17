using System.Collections;
using UnityEngine;

public class VelocitySpirit : MonoBehaviour
{
    private PlayerStatistic _playerStatistic;
    private PlayerMoving _playerInfo;
    public GameObject attackZone;
   
    public float BounceVelocity;
    


    private float boostedSpeed = 6f;
    private float timeBetweenBounce;
    private float startTimeBetweenBounce = 2f;

    private void Start()
    {
        _playerStatistic = GetComponent<PlayerStatistic>();
        _playerInfo = GetComponent<PlayerMoving>();
        _playerStatistic.speed = boostedSpeed;
       
    }   

    private void FixedUpdate()
    {
        if(timeBetweenBounce <= 0 && Input.GetKey(KeyCode.R))
        {
            StartCoroutine("Bounce");
            if (_playerInfo.isRight == false)
            {
                transform.Translate(new Vector3(-5, 0, 0) * BounceVelocity);
            }
            if (_playerInfo.isRight == true)
            {
                transform.Translate(new Vector3(5, 0, 0) * BounceVelocity);
            }

            

            timeBetweenBounce = startTimeBetweenBounce;
        }
        else 
        {
            timeBetweenBounce -= Time.deltaTime;
        } 
        
    }


    private IEnumerator Bounce()
    {
        Instantiate(attackZone, gameObject.transform);
        yield return new WaitForSeconds(0.12f);
        Destroy(transform.Find("attackZone(Clone)").gameObject);
    }
}
