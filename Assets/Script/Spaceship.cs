using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float hp;
    public bool shield;
    public float cdShield;
    public float maxFuel;
    public float actualFuel;
    float timeBeforeLast;
    public List<Module> ModulesInventary = new List<Module>();
    public Module[] AllModules;
    public Extract extract;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        actualFuel = maxFuel;
        foreach(var module in AllModules)
        {
            module.willBeseeOnContent = true;
            module.alreadyHad = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeLast += Time.deltaTime;  // ajoute a chaque update le temps écoulé depuis le dernier Update		
        if (timeBeforeLast > 1)
        {
            actualFuel--;
            timeBeforeLast = 0;
            if(actualFuel <= 0)
            {
                die();
            }
        }
    }

    void die()
    {
        Destroy(player.gameObject);
        Destroy(this.gameObject);
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
    public void ModuleInInventory()
    {
        List<Module> modulesTemp = new List<Module>();
        List<string> modulesTypes = new List<string>();
        foreach (Module mod in AllModules)
        {
            bool dontAlreadyHaveTheType = false;
            foreach (string types in modulesTypes)
            {
                if (mod.type == types)
                {
                    dontAlreadyHaveTheType = true;
                }
            }
            if (mod.alreadyHad == false && dontAlreadyHaveTheType == false)
            {
                modulesTemp.Add(mod);
                modulesTypes.Add(mod.type);
            }
        }
        foreach (Module mod in modulesTemp)
        {

        }
        Module module = modulesTemp[Random.Range(0, modulesTemp.Count)];
        ModulesInventary.Add(module);
        foreach (Module mod in AllModules)
        {
            if (mod.name == module.name)
            {
                mod.alreadyHad = true;
            }
        }
    }
    public void GetSomeModule(GameObject TheITemWhichIsExtract)
    {
        TheITemWhichIsExtract.GetComponent<ItemInSpace>().Die();
        extract.isExtracted = false;
        ModuleInInventory();
    }
    IEnumerator RespawnTheShield()
    {
        yield return new WaitForSeconds(cdShield);
        shield = true;
    }
}
