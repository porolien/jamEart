using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 movement = Vector2.zero;
    bool canGoDown;
    bool canGoUp;
    public float speed;
    Rigidbody rb;
    public Pause pause;
    SpriteRenderer renderer = null;
    Animator animator = null;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
        if(movement.x != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }
    void OnMovement (InputValue moveValue)
    {
        
        movement = new Vector2 (moveValue.Get<Vector2>().x, 0);
        if (movement.x != 0)
        {
            renderer.flipX = movement.x < 0;
        }
        if (canGoDown && moveValue.Get<Vector2>().y < 0)
        {
            StartCoroutine(Climb(new Vector3(transform.position.x, -6.14f, -0.1f)));
            
           
        }
        if (canGoUp && moveValue.Get<Vector2>().y > 0)
        {
           
            StartCoroutine(Climb(new Vector3(transform.position.x, -3.47f, -0.1f)));
        }
       
    }
    /*void OnMovement(InputValue moveValue)
    {
        Debug.Log("test");
        if(onStairs)
        {
            movement = moveValue.Get<Vector2>();
        }
        movement.x = moveValue.Get<Vector2>().x;
    }*/
    void OnUseItem()
    {
      
    }
    void OnPause()
    {
        pause.PauseFonction();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "lowStairs")
        {
             canGoUp = true;
        }
        else if (other.tag == "highStairs")
        {
            canGoDown = true;
        }
        if (other.tag == "interactItem")
        {
            other.GetComponent<InteractItem>().hoverOnItem();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "lowStairs")
        {
            canGoUp = false;
        }
        else if (other.tag == "highStairs")
        {
            canGoDown = false;
        }
        if (other.tag == "interactItem")
        {
            other.GetComponent<InteractItem>().disableTheHover();
        }
    }
    IEnumerator Climb(Vector3 StairsPosition)
    {
        animator.SetBool("IsClimbing", true);
        yield return new WaitForSeconds(0.2f);
        transform.position = StairsPosition;
        animator.SetBool("IsClimbing", false);

    }
}
