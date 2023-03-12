using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Spaceship fuelFromSpaceship;
    public Image EmptyFuelBar;
    public Image FuelBarFilled;
    // Start is called before the first frame update
    
    public void UpdateTheBar()
    {
        FuelBarFilled.fillAmount = fuelFromSpaceship.actualFuel/ fuelFromSpaceship.maxFuel;
    }
}
