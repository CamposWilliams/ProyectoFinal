using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float movementspeed;
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    private bool isGrounded;
    public int playerLives = 5; 

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 velocity = Vector3.zero;

        if (hor != 0 || ver != 0)
        {
            Vector3 direction = (transform.forward * ver + transform.right * hor).normalized;
            velocity = direction * movementspeed;
        }

        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    }

    public void TakeDamage(int damage)
    {
        playerLives -= damage;

        if (playerLives <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1); 
        }
    }
}