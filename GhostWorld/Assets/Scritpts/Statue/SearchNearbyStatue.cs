using System.Collections;
using UnityEngine;

public class SearchNearbyStatue : MonoBehaviour
{
    public LayerMask Statue;

    public Transform playerPosition;
    public Transform closestStatuePosition;


    public float range;
    private float speedAdded = 100f;
    private float timeBetweenReload = 2f;
    private bool isReloaded = false;

    private void Update()
    {
        Collider2D Statues = Physics2D.OverlapCircle(playerPosition.position, range, Statue);
        if(Statues != null)
        {
           closestStatuePosition = Statues.transform;
        }

        if(closestStatuePosition == null)
        {
            if (range >= 0 && range <= 300)
            {
                range += 1 * speedAdded * Time.deltaTime;
            }
        }
        else
        {
            range = 0;
        }
        
        if(isReloaded == false)
        {
            isReloaded = true;
            StartCoroutine("startSearching");
        }
        
    }
     
    private IEnumerator startSearching()
    {  
        yield return new WaitForSeconds(timeBetweenReload);
        isReloaded = false;
        closestStatuePosition = null;
        range = 0;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(playerPosition.position, range);
    }

}
