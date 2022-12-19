using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float Jump;

    private Rigidbody2D rigidbody;
    private float moveVelocity;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, Jump);
            }
        }

        moveVelocity = 0;

        //Left Right Movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveVelocity = -Speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveVelocity = Speed;
        }

        rigidbody.velocity = new Vector2(moveVelocity, rigidbody.velocity.y);

    }
    //Check if Grounded
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        isGrounded = true;
    }
    void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("OnCollisionExit2D");
        isGrounded = false;
    }
}
