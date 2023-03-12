using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour
{
    public float hp;
    public float attack;
    public bool canTakeDmg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void die()
    {
        Destroy(gameObject);
    }
    void TakeDmg(float dmg)
    {
        hp = hp - dmg;
        if(hp <= 0)
        {
            die();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "projectil")
        {
            if(canTakeDmg)
            {
                Projectil Projectible = other.GetComponent<Projectil>();
                Debug.Log(Projectible.attack);
                TakeDmg(Projectible.attack);
                if (Projectible.isDestructible)
                {
                    Destroy(other.gameObject);
                }

                else
                {
                    StartCoroutine(invincible());
                }
            }
           
        }
        if (other.tag == "spaceship")
        {
            other.GetComponent<Spaceship>().TakeDmg(attack);
            die();
        }

    }
   
    IEnumerator invincible()
    {
        canTakeDmg = false;
        yield return new WaitForSeconds(0.2f);
        canTakeDmg = true;
    }
}
