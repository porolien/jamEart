using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extract : MonoBehaviour
{
    GameObject TheExtractedItem;
    public Transform vaisseau;
    public float extractSpeed;
    public bool isExtracted;
    public bool extractIsActivated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (extractIsActivated)
        {
            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 10000))
                {
                    TheExtractedItem = hit.transform.gameObject;
                    if (TheExtractedItem.tag == "extractItem")
                    {
                        //extractTheItem(TheExtractedItem, true);
                        isExtracted = true;
                        TheExtractedItem.GetComponent<ItemInSpace>().isExtracted = true;
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (isExtracted)
                {
                    isExtracted = false;
                    if (TheExtractedItem != null)
                    {
                        TheExtractedItem.GetComponent<ItemInSpace>().isExtracted = false;
                        // extractTheItem(TheExtractedItem, false);
                        TheExtractedItem.GetComponent<Rigidbody>().velocity = new Vector2(/*speed.x * direction.x, speed.y * direction.y*/ 5 * -1, 5 * -1);
                    }
                }
            }
            if (isExtracted)
            {
                TheExtractedItem.transform.position = Vector2.MoveTowards(TheExtractedItem.transform.position, vaisseau.position, extractSpeed * Time.deltaTime);
                transform.up = (transform.position - vaisseau.position).normalized;
                //faire comme les kamikaze
            }
        }
    }

    void extractTheItem(GameObject Item, bool isExtracted)
    {
        if (isExtracted)
        {
            Debug.Log("fast");
            TheExtractedItem.transform.position = Vector2.MoveTowards(transform.position, vaisseau.position, extractSpeed * Time.deltaTime);
            transform.up = (transform.position - vaisseau.position).normalized;
            //faire comme les kamikaze
        }
        else
        {
            TheExtractedItem.GetComponent<Rigidbody>().velocity = new Vector2(/*speed.x * direction.x, speed.y * direction.y*/ 5 * -1, 5 * -1);

            //le faire avancer tout droit
        }
    }
}
