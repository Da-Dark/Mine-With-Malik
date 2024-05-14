using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public int gold;
    public int storageCost = 5;
    public int healthCost = 15;
    public PlayerController playerControllerScript;
    public TextMeshProUGUI BuyStorageText;
    public TextMeshProUGUI BuyHeartsText;


    public void IncreaseHealth ()
    {
        if (playerControllerScript.gold >= healthCost)
        {
            playerControllerScript.gold -= healthCost;
            playerControllerScript.PlayerHealth += 1;

            healthCost += 1;

            BuyHeartsText.text = "Buy Hearts $" + healthCost;

            playerControllerScript.UpdateGold();



        }
    }


    public void IncreaseStorage()
    {
        if (playerControllerScript.gold >= storageCost)
        {
            playerControllerScript.gold -= storageCost;
            playerControllerScript.storage += 5;

            storageCost += 5;

            BuyStorageText.text = "Buy Storage $" + storageCost;

            playerControllerScript.UpdateGold();
        }
    }
}
