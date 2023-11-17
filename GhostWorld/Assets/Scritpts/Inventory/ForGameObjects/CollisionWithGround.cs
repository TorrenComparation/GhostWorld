using UnityEngine;

public class CollisionWithGround : MonoBehaviour
{
    private GameObject player;
    private PlayerMoving statistic;
    private Rigidbody2D itemPhysic;
    public LayerMask ground;
    private float range = 0.35f;
    private bool IsGrounded;
    private float rotationSpeed = 60f;
    private bool direction;

    private void Start()
    {
        itemPhysic = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        statistic = player.GetComponent<PlayerMoving>();

        if(statistic.isRight == true)
        {
          direction = true;
        }
        else
        {
            direction = false;
        }
        
    }

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(gameObject.transform.position, range, ground);
        if(IsGrounded == true)
        {
            itemPhysic.bodyType = RigidbodyType2D.Static;
        }
        else if(IsGrounded == false) 
        {
            itemPhysic.bodyType = RigidbodyType2D.Dynamic;
            if(direction == true)
            {
                gameObject.transform.Rotate(Vector3.forward * (-rotationSpeed) * Time.deltaTime);
            }
            else if(direction == false)
            {
                gameObject.transform.Rotate(Vector3.forward * (rotationSpeed) * Time.deltaTime);
            }

        }
    
       
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gameObject.transform.position, range);
    }
}
