using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 4f;
    private float speedNeg = 0;

    private Rigidbody2D body2d;
    private Animator animator;

    public GameObject cam;
    public GameObject Inventory;

    private string from = "Down";

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, -10);

        speedNeg = speed - speed - speed;

        AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorClipInfo[] animatorClip = animator.GetCurrentAnimatorClipInfo(0);
        float Time = animatorClip[0].clip.length * animationState.normalizedTime;

        animator.speed = speed / 4;

        if (Input.GetKey("w") && Input.GetKey("d"))
        {
            body2d.velocity = new Vector2(speed, speed);
            changeOrientation("Up", Time);
        }
        else if (Input.GetKey("w") && Input.GetKey("a"))
        {
            body2d.velocity = new Vector2(speedNeg, speed);
            changeOrientation("Up", Time);
        }
        else if (Input.GetKey("s") && Input.GetKey("a"))
        {
            body2d.velocity = new Vector2(speedNeg, speedNeg);
            changeOrientation("Down", Time);
        }
        else if (Input.GetKey("s") && Input.GetKey("d"))
        {
            body2d.velocity = new Vector2(speed, speedNeg);
            changeOrientation("Down", Time);
        }
        else if (Input.GetKey("w"))
        {
            body2d.velocity = new Vector2(0, speed);
            changeOrientation("Up", Time);
        }
        else if (Input.GetKey("s"))
        {
            body2d.velocity = new Vector2(0, speedNeg);
            changeOrientation("Down", Time);
        }
        else if (Input.GetKey("a"))
        {
            body2d.velocity = new Vector2(speedNeg, 0);
            changeOrientation("Left", Time);
        }
        else if (Input.GetKey("d"))
        {
            body2d.velocity = new Vector2(speed, 0);
            changeOrientation("Right", Time);
        }
        else
        {
            body2d.velocity = new Vector2(0, 0);
            if (from != "idle")
            {
                animator.speed = 1000;
            }
            from = "idle";
            //changeOrientation("Idle-" + from, Time);           
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        InventoryManager inv = new InventoryManager();
        inv.AddItemToInv(coll);
    }

    private void changeOrientation(string movement, float Time)
    {
        //print(Time);      
        if (Time >= 0.95 && from == movement)
        {
            animator.SetTrigger(movement);
        }
        else if (from != movement)
        {
            animator.SetTrigger(movement);
            from = movement;
        }
    }
}
