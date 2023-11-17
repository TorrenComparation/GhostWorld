using System;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public GameObject Player;
    public Transform dropPosition;
    private Rigidbody2D rb;
    private PlayerStatistic _playerStatistic;
    public Transform feetPosition;
    public LayerMask Ground;

    private float speed;
    private float jumpForce = 5f;
    public float ourRadius;
    private float moveInput;

    [NonSerialized] public bool isCanMove = true;
    [NonSerialized] public bool isRight = true;
    [NonSerialized] public bool isGrounded = false;


    private void Start()
    {
        _playerStatistic = GetComponent<PlayerStatistic>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {

        speed = _playerStatistic.speed;
       
        if(isCanMove == true)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            transform.position += new Vector3(moveInput * speed, 0, 0) * Time.deltaTime;

            if (moveInput > 0 && isRight == false)
            {
                Flip();
            }
            else if (moveInput < 0 && isRight == true)
            {
                Flip();
            }

            isGrounded = Physics2D.OverlapCircle(feetPosition.position, ourRadius, Ground);

            if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
    }

    private void Flip()
    {
        isRight = !isRight;
        Vector2 PlayerScaler = transform.localScale;
        PlayerScaler.x *= -1;
        transform.localScale = PlayerScaler;
    }
}
