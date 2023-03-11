using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractivImage : MonoBehaviour
{
    bool itsMoving;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    GameObject image;
    Transform parent;
    public GameObject TopTurret;
    public GameObject BottomTurret;
    public GameObject Light;
    public GameObject Jukebox;
    public GameObject Shield;
    public GameObject Extractor;
    // Start is called before the first frame update
    void Start()
    {
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (itsMoving == true)
        {
            GameObject tagOfGameObject = null;
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            m_Raycaster.Raycast(m_PointerEventData, results);
            foreach (RaycastResult result in results)
            {
                image.transform.position = result.screenPosition;
                if (result.gameObject.tag == "ModuleInput")
                {
                    tagOfGameObject = result.gameObject;
                }
            }
            if(Input.GetMouseButtonDown(0) && tagOfGameObject.tag == "ModuleInput")
            {
                tagOfGameObject.transform.GetChild(0).gameObject.SetActive(false);
                image.transform.SetParent(tagOfGameObject.transform, false);
                image.transform.localPosition = new Vector3(0, 0, 0); ;
                itsMoving = false;
            }
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log(image.GetComponent<Module>().type);
                image.transform.SetParent(parent, false);
                itsMoving = false;
            }
        }
    }
    public void moveImage(GameObject imageClicked, Transform Parent)
    {
        itsMoving = true;
        parent = Parent;
        imageClicked.transform.SetParent(transform, false);
        image = imageClicked;
        switch (imageClicked.GetComponent<Module>().type)
        {
            case "jukebox":
                Jukebox.SetActive(true);
                break;
            case "shield":
                Shield.SetActive(true);
                break;
            case "turret":
                BottomTurret.SetActive(true);
                TopTurret.SetActive(true);
                break;
            case "extractor":
                Extractor.SetActive(true);
                break;
            case "light":
                Light.SetActive(true);
                break;
        }
    }
}
