using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public static CharacterMove instance;
    public Transform checkWallPoint;
    public Transform checkGroundPoint;

    private Rigidbody2D rb;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (G1GameManager.instance.state == G1GameManager.GameState.Stop) 
        {
            return; 
        }

        if (GroundCheck())
        {
            rb.velocity = transform.right * 50 * Time.fixedDeltaTime;
        }

        if(WallCheck())
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.parent = collision.transform;
    }


    public void StaticRigidbody(bool isStatic)
    {
        if(!isStatic)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            gameObject.layer = 6;
        }
        else
        {
            rb.bodyType= RigidbodyType2D.Kinematic;
            rb.velocity = Vector2.zero;
            gameObject.layer = 31;
        }
    }

    //Check
    public bool WallCheck()
    {
        return Physics2D.Raycast(checkWallPoint.position, transform.right, 0.02f, LayerMask.GetMask("Ground"));
    }
    public bool GroundCheck()
    {
        return Physics2D.OverlapCircle(checkGroundPoint.position, 0.1f, LayerMask.GetMask("Ground"));
    }
}
