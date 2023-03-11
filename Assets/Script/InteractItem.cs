using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractItem : MonoBehaviour
{
    Animator animator;
    public string itemName;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hoverOnItem()
    {
        animator.SetBool("IsHovered", true);
    }
    public void disableTheHover()
    {
        animator.SetBool("IsHovered", false);
    }
}
