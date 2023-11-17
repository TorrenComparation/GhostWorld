using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] public GameObject item;
    private GameObject player;
    private PlayerMoving statistic;
   

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        statistic = player.GetComponent<PlayerMoving>();
    }

   
    public void SpawnDroppedItem()
    {
        if(statistic.isRight == true)
        {
            Vector2 playerPos = player.transform.position;
            Instantiate(item, playerPos, Quaternion.identity);
        }
        else if(statistic.isRight == false)
        {
            Vector2 playerPos = player.transform.position;
            Instantiate(item, playerPos, Quaternion.identity);
        }
        
    }
}
