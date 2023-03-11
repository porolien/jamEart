using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEAPON : MonoBehaviour
{
    float cd;
    string WeaponType;
    public float attack;
    public GameObject TheExtractedItem;
    public GameObject bullet;
    public GameObject laser;
    Vector3 worldPosition;
    public Transform shootPos;
    float SpeedBullet = 5;
    public bool isDestructible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000))
            {
               
              
                transform.right = -((transform.position - hit.point).normalized);
            }
        if (Input.GetMouseButtonDown(0))
        {
            Shoot(hit.point);
        }

    }

    void Shoot(Vector3 ShootDirection)
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.transform.position = Vector2.MoveTowards(transform.position, shootPos.position, 5 * Time.deltaTime);
        newBullet.transform.right = (transform.position - shootPos.position).normalized;
        Projectil statBullet = newBullet.GetComponent<Projectil>();
        statBullet.attack = attack;
        statBullet.isDestructible = isDestructible ;
        StartCoroutine(waitToMakeItTrigger(newBullet));
    }
    IEnumerator waitToMakeItTrigger(GameObject Bullet)
    { 
        yield return new WaitForSeconds(0.1f);
        Bullet.GetComponent<CapsuleCollider>().isTrigger = true;
    }
}