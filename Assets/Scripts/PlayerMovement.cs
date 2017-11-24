using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 4f;
    private float speedNeg = 0;

    private Rigidbody2D body2d;
    private Animator animator;

    public GameObject cam;

    private string from;

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        speedNeg = speed - speed - speed;

    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, -10);
        
        if (Input.GetKey("w") && Input.GetKey("d"))
        {
            body2d.velocity = new Vector2(speed, speed);
            changeOrientation("Up");
        }
        else if (Input.GetKey("w") && Input.GetKey("a"))            
        {
            body2d.velocity = new Vector2(speedNeg, speed);
            changeOrientation("Up");
        }
        else if (Input.GetKey("s") && Input.GetKey("a"))
        {
            body2d.velocity = new Vector2(speedNeg, speedNeg);
            changeOrientation("Down");
        }
        else if (Input.GetKey("s") && Input.GetKey("d"))
        {
            body2d.velocity = new Vector2(speed, speedNeg);
            changeOrientation("Down");
        }
        else if (Input.GetKey("w"))
        {
            body2d.velocity = new Vector2(0, speed);
            changeOrientation("Up");
        }
        else if (Input.GetKey("s"))
        {
            body2d.velocity = new Vector2(0, speedNeg);
            changeOrientation("Down");
        }
        else if (Input.GetKey("a"))
        {
            body2d.velocity = new Vector2(speedNeg, 0);
            changeOrientation("Left");
        }
        else if (Input.GetKey("d"))
        {
            body2d.velocity = new Vector2(speed, 0);
            changeOrientation("Right");        
        }
        else
        {
            body2d.velocity = new Vector2(0, 0);
            //changeOrientation("Idle");
        }
    }

    private void changeOrientation(string movement)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("player_idle") || from != movement)
        {
            animator.SetTrigger(movement);
            from = movement;
        }
    }
}
