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

    void Start() // initialize cost at shop properly
    {
        storageCost = 5;
        healthCost = 15;
    }
    public void IncreaseHealth ()
    {
        // Debug.Log("Player has " + playerControllerScript.CompareGold() + " gold");
        // Debug.Log("Health cost " + healthCost + " gold");

        if (playerControllerScript.CompareGold() >= healthCost)
        {
            playerControllerScript.RemoveGold(healthCost);
            playerControllerScript.AddHearts(1);

            healthCost += 1;

            playerControllerScript.UpdateGold(); // buggy

            
        }

        BuyHeartsText.text = "Buy Hearts $" + healthCost + ".00"; // add .00 to be more consistant
    }


    public void IncreaseStorage()
    {
        // Debug.Log("Player has " + playerControllerScript.CompareGold() + " gold");

        if (playerControllerScript.CompareGold() >= storageCost)
        {
            playerControllerScript.RemoveGold(healthCost);
            playerControllerScript.storage += 5;

            storageCost += 5;  

            playerControllerScript.UpdateGold(); // buggy

        }
        BuyStorageText.text = "Buy Storage $" + storageCost + ".00"; // add .00 to be more consistant
    }
}

