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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }
    void OnMovement (InputValue moveValue)
    {
        Debug.Log("test");
        movement = new Vector2 (moveValue.Get<Vector2>().x, 0);
        if (canGoDown && moveValue.Get<Vector2>().y < 0)
        {
           transform.position = new Vector2(transform.position.x, -1.23f);
        }
        if (canGoUp && moveValue.Get<Vector2>().y > 0)
        {
            transform.position = new Vector2(transform.position.x, 1.49f);
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
        Debug.Log("test");
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
}
