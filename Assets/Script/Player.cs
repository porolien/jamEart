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
    GameObject interactObject;
    public PlayerInput action;
    public WEAPON weapon;
    public Extract extract;
    public GameObject PCHUD;
    string InteractItemChanged;
    public UIPC UIPC;
    public GameObject TheJukebox;
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
      if(interactObject != null)
        {
            switch (interactObject.GetComponent<InteractItem>().itemName)
            {
                case "weapons":
                    action.SwitchCurrentActionMap("StopMovement");
                    weapon.WeaponActivate = true;
                    InteractItemChanged = "weapons";
                    break;
                case "cockpit":
                    action.SwitchCurrentActionMap("StopMovement");
                    extract.extractIsActivated = true;
                    InteractItemChanged = "cockpit";
                    break;
                case "pc":
                    action.SwitchCurrentActionMap("StopMovement");
                    PCHUD.SetActive(true);
                   // pause.Paus(false);
                    InteractItemChanged = "pc";
                    UIPC.initPC();
                    break;
                case "jukebox":
                    action.SwitchCurrentActionMap("StopMovement");
                    TheJukebox.SetActive(true);
                    // pause.Paus(false);
                    InteractItemChanged = "jukebox";
                    break;
            }
        }
    }
    void OnPause()
    {
        pause.Paus(true);
    }
    void OnEscape()
    {
        action.SwitchCurrentActionMap("PlayerMovement");
        switch (InteractItemChanged)
        {
            case "weapons":
                weapon.DesactivateAllTurret();
                break;
            case "cockpit":
                extract.extractIsActivated = false;
                break;
            case "pc":
                PCHUD.SetActive(false);
             //   pause.Resume(false);
                break;
            case "jukebox":
                TheJukebox.SetActive(false);
                break;
        }
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
            interactObject = other.gameObject;
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
            interactObject = null;
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
