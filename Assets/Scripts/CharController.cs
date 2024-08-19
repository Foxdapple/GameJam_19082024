using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    float moveInput;

    Rigidbody2D rb;

    bool facingRight = true;
    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0){
            Flip();
        }
        else if(facingRight == true && moveInput < 0){
            Flip();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = Vector2.up * JumpForce;
        }
    }

    void Flip(){
        facingRight = !facingRight;
        Vector3 Scalar = transform.localScale;
        Scalar.x *= -1;
        transform.localScale = Scalar;
    }
}
