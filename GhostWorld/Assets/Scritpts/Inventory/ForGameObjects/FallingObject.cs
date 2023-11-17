using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public GameObject player;
    public Transform dropPosition;

    private Transform startPoint; 
    private Transform endPoint;   
    private float speed = 10f;  

    private float startTime;
    private float journeyLength;
    private float playerChecker = 1f;
    private float distance;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dropPosition = player.transform.Find("DropPosition");

         
       
        if (player != null)
        {
           
            startPoint = player.transform;
            endPoint = dropPosition;
        }
       
      
        journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
        startTime = Time.time;
    }

    private void Update()
    {
         distance = Vector2.Distance(gameObject.transform.position, player.transform.position);
        if (distance < playerChecker)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;

            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, fractionOfJourney);

            if (fractionOfJourney >= 1.0f)
            {
                Destroy(gameObject.GetComponent<FallingObject>());
            }
        }
        else if (distance > playerChecker) 
        {
            Destroy(gameObject.GetComponent<FallingObject>());
        }
        
    }
}