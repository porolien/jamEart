using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInSpace : MonoBehaviour
{
    public string typeOfObject;
    public bool isExtracted;
    public float speed;
    public Vector2 direction;
    Rigidbody rb;
    //public bool isAModule;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "spaceship")
        {
            if(typeOfObject == "fuel" || typeOfObject == "cometShard")
            {
                other.GetComponent<Spaceship>().GetSomeFuel(gameObject);
                Die();
            }
            if (typeOfObject == "wreck")
            {
                other.GetComponent<Spaceship>().GetSomeModule(gameObject);
                Destroy(this);
            }

        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
