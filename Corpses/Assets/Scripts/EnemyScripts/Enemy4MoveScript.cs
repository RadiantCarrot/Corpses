using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4MoveScript : MonoBehaviour
{
    public GameObject spawnFlash;

    public GameObject enemy4;
    Rigidbody2D rb;

    public GameObject enemy4Sprite;
    public bool facingRight;

    public float vibrateSpeed;
    public float vibrateIntensity;
    public Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(spawnFlash, transform.position, Quaternion.identity); // create spawn flash effect
        rb = GetComponent<Rigidbody2D>(); // assigns rigidbody to character

        scaleChange = new Vector3(-0.01f, -0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        enemy4.transform.localScale += scaleChange; // increase scale

        if (enemy4.transform.localScale.y < 0.8f || enemy4.transform.localScale.y > 1.2f) // if scale hits limit
        {
            scaleChange = -scaleChange; // decrease scale
        }
    }

    float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir); // check for axis direction
        float dir = Vector3.Dot(perp, up); // check for the other axis direction

        if (dir > 0f && !facingRight) // if player is to the right and face right check is false, flip
        {
            Flip();
            return 1f; // target is on the right
        }
        else if (dir < 0f && facingRight) // if player is to the left and face right check is true, flip
        {
            Flip();
            return -1f; // target is on the left
        }
        else
        {
            return 0f; // target is straight ahead or behind
        }
    }

    void Flip()
    {
        Vector3 currentScale = enemy4Sprite.transform.localScale; // check direction enemy is facing
        currentScale.x *= -1;
        enemy4Sprite.transform.localScale = currentScale; // flip enemy sprite

        facingRight = !facingRight;
    }
}
