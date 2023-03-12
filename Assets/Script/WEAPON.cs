using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEAPON : MonoBehaviour
{
    public float cd;
    string WeaponType;
    bool waitCd;
    public float attack;
    public GameObject TheExtractedItem;
    public GameObject bullet;
    public GameObject laser;
    Vector3 worldPosition;
    public Transform shootSpawn;
    public Transform shootPos;
    float SpeedBullet = 10;
    public bool isDestructible;
    public bool WeaponActivate;
    public bool EnableTheSecondWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (WeaponActivate)
        {
            if(EnableTheSecondWeapon && (Input.GetButtonDown("S")|| Input.GetButtonDown("Z")))
            {

            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000))
            {

                Debug.Log(hit.point);
                transform.up = ((hit.point - transform.position).normalized);
            }
            if (Input.GetMouseButtonDown(0) && !waitCd)
            {
                StartCoroutine(onCd());
                Shoot(hit.point);
            }
        }
    }

    void Shoot(Vector3 ShootDirection)
    {
        Debug.Log(ShootDirection);
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        // newBullet.transform.position = Vector2.MoveTowards(transform.position, ShootDirection, 20 * Time.deltaTime);
        float totalDirectionX = (ShootDirection.x + ShootDirection.y);
        float totalDirectionY = totalDirectionX;
       if ((ShootDirection.x / totalDirectionX > 0 && ShootDirection.x < 0) || (ShootDirection.x / totalDirectionX < 0 && ShootDirection.x > 0))
        {
            if(ShootDirection.y / totalDirectionY > 0 && ShootDirection.y < 0 || (ShootDirection.y / totalDirectionY < 0 && ShootDirection.y > 0))
            {
                totalDirectionY = -totalDirectionY;
            }
            totalDirectionX = -totalDirectionX;
        }
        newBullet.GetComponent<Rigidbody>().velocity = new Vector2((ShootDirection.x / totalDirectionX), (ShootDirection.y / totalDirectionY));
        newBullet.GetComponent<Rigidbody>().velocity = (Vector3.Normalize(newBullet.GetComponent<Rigidbody>().velocity) * SpeedBullet);
        newBullet.transform.right = (transform.position - ShootDirection).normalized;
        Projectil statBullet = newBullet.GetComponent<Projectil>();
        statBullet.attack = attack;
        statBullet.isDestructible = isDestructible ;
    }
    IEnumerator onCd()
    {
        waitCd = true;
        yield return new WaitForSeconds(cd);
        waitCd = false;
    }
  
}
