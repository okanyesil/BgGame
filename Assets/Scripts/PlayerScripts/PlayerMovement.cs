using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _myBody;

    public float moveSpeed = 3f;
    // Start is called before the first frame update
    void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.0f)
        {
            _myBody.velocity = new Vector2(moveSpeed,_myBody.velocity.y);
        }
        if (Input.GetAxisRaw("Horizontal") < 0.0f)
        {
            _myBody.velocity = new Vector2(-moveSpeed,_myBody.velocity.y);
        }
        
    }

    public void PlatformMove(float x)
    {
        _myBody.velocity = new Vector2(x,_myBody.velocity.y);
    }
}
