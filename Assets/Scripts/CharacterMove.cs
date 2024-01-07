using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Transform checkWallPoint;
    public Transform checkGroundPoint;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (GroundCheck())
        {
            rb.velocity = transform.right * 50 * Time.fixedDeltaTime;
        }

        if(WallCheck())
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }


    public bool WallCheck()
    {
        return Physics2D.Raycast(checkWallPoint.position, Vector2.right, 0.01f, LayerMask.GetMask("Ground"));
    }
    public bool GroundCheck()
    {
        return Physics2D.OverlapCircle(checkGroundPoint.position, 0.1f, LayerMask.GetMask("Ground"));
    }
}
