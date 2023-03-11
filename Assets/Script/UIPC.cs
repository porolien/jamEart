using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIPC : MonoBehaviour
{
    public GameObject Content;
    public Spaceship modules;
    public GameObject canva;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void initPC()
    {
        foreach (Transform child in Content.transform)
        {
                Destroy(child.gameObject);
        }
        foreach (var module in modules.ModulesInventary)
        {
            Image NewImage = Instantiate(module.image, Content.transform, false);
            NewImage.AddComponent<Module>().type = module.type;
            NewImage.AddComponent<Button>().onClick.AddListener(delegate { beginInteractable(NewImage); });
        }
    }
    void beginInteractable(Image theImage)
    {   
        canva.GetComponent<InteractivImage>().moveImage(theImage.gameObject, Content.transform);
    }
}
