using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float hp;
    public bool shield;
    public float cdShield;
    public float maxFuel;
    float actualFuel;
    float timeBeforeLast;
    public List<Module> ModulesInventary = new List<Module>();
    public Module AllModules;
    public Extract extract;
    // Start is called before the first frame update
    void Start()
    {
        actualFuel = maxFuel;
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeLast += Time.fixedDeltaTime;  // ajoute a chaque update le temps écoulé depuis le dernier Update		
        if (timeBeforeLast > 1)
        {
            actualFuel--;
            timeBeforeLast = 0;
        }
    }

    void die()
    {
        Destroy(this);
    }

    public void TakeDmg(float dmg)
    {
        if (shield)
        {
            shield = false;
            StartCoroutine(RespawnTheShield());
        }
        else
        {
            hp = hp - dmg;
            if (hp <= 0)
            {
                die();
            }
            Debug.Log(hp);
        }
    }
    public void GetSomeFuel(GameObject TheITemWhichIsExtract)
    {
        TheITemWhichIsExtract.GetComponent<ItemInSpace>().Die();
        extract.isExtracted = false;
        actualFuel = actualFuel + maxFuel / 3;
        if(actualFuel > maxFuel)
        {
            actualFuel = maxFuel;
        }
    }
    public void GetSomeModule(GameObject TheITemWhichIsExtract)
    {
        TheITemWhichIsExtract.GetComponent<ItemInSpace>().Die();
        extract.isExtracted = false;
        List<Module> modulesTemp = new List<Module>();
        List<string> modulesTypes = new List<string>();
        foreach (Module mod in AllModules.modules)
        {
            bool dontAlreadyHaveTheType = false;
            foreach(string types in modulesTypes)
            {
                if (mod.type == types) 
                {
                    dontAlreadyHaveTheType = true;
                } 
            }
            if(mod.alreadyHad == false && dontAlreadyHaveTheType == false)
            {
                modulesTemp.Add(mod);
                modulesTypes.Add(mod.type);
            }
        }
        Module module = modulesTemp[Random.Range(0, modulesTemp.Count)];
        ModulesInventary.Add(module);
        foreach(Module mod in AllModules.modules)
        {
            if(mod.name == module.name)
            {
                mod.alreadyHad = true;
            }
        }
    }
    IEnumerator RespawnTheShield()
    {
        yield return new WaitForSeconds(cdShield);
        shield = true;
    }
}
