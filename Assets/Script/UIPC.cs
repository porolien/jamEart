using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPC : MonoBehaviour
{
    public GameObject Content;
    public Spaceship modules;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            initPC();
        }
    }
    void initPC()
    {
        foreach (Transform child in Content.transform)
        {
                Destroy(child.gameObject);
        }
        foreach (var module in modules.ModulesInventary)
        {
            Image NewImage = Instantiate(module.image, Content.transform, false);
        }
    }
}
