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
    public FuelBar FuelBar;
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
        FuelBar.UpdateTheBar();
        foreach (Transform aChild in Content.transform)
        {
                Destroy(aChild.gameObject);
        }
        foreach (Module module in modules.ModulesInventary)
        {
            if (module.willBeseeOnContent)
            {
                Module NewImage = Instantiate(module, Content.transform, false);
                Image theImage = NewImage.gameObject.AddComponent<Image>();
                theImage.sprite = module.image.sprite;
                NewImage.AddComponent<Button>().onClick.AddListener(delegate { beginInteractable(NewImage); });
            }
        }
    }
    void beginInteractable(Module theImage)
    {   
        canva.GetComponent<InteractivImage>().moveImage(theImage.gameObject, Content.transform);
    }
}
