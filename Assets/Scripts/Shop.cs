using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int gold;
    public int storage;
    public int health;
    public int storageCost;
    public int healthCost;

    public void IncreaseHealth ()
    {
        if (gold >= healthCost)
        {
            gold -= healthCost;
            health += 1;
        }
    }

    public void IncreaseStorage()
    {
        if (gold >= storageCost)
        {
            gold -= storageCost;
            storage += 1;
        }
    }
}
