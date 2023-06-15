using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    Vector2 moveDir;

    public float moveSpeed = 10f;
    private float activeMoveSpeed;

    public bool isMoving;
    public bool facingRight = true;
    public GameObject playerSprite;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // assigns rigidbody to character
        activeMoveSpeed = moveSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // geting player direction
        rb.velocity = moveDir.normalized * activeMoveSpeed; // actually moving the player

        // ~~~~~ Flipping ~~~~~

        if (moveDir.x > 0 && !facingRight) // if moving left and facing left, flip
        {
            Flip();
        }
        if (moveDir.x < 0 && facingRight) // if moving right and facing right, flip
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = playerSprite.transform.localScale; // check direction player is facing
        currentScale.x *= -1;
        playerSprite.transform.localScale = currentScale; // flip player sprite

        facingRight = !facingRight;
    }
}
