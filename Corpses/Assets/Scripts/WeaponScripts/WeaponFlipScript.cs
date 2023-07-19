using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Done by KarLonng

public class WeaponFlipScript : MonoBehaviour
{
    private Camera cam;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position; // get direction of mouse cursor
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; // point weapon in direction of cursor

        if (angle < 89 && angle > -89)
        {
            spriteRenderer.flipY = false; // no flip gun
        }
        else
        {
            spriteRenderer.flipY = true; // flip gun
        }
    }
}
