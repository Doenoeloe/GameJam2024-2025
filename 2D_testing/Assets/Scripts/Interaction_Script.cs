using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Script : MonoBehaviour
{
    //All using variables
    public GameObject interact_E;
    public GameObject upgradesUI;
    public bool Interact_Bool = false;
    public string ID = "";
    private bool isPlayerInRange = false;
    private bool isUpgrading = false; // Added to track the upgrade UI state

    //Checks for collision enter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Toggle();
        }
    }
    //Check for collision exit
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interact_E.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            InteractionCheck();
        }
        if (isUpgrading && Input.GetKeyDown(KeyCode.Q))
        {
            CloseUpgradeUI();
        }
    }

    public void Toggle()
    {
        if (!Interact_Bool)
        {
            interact_E.SetActive(true);
        }
    }

    public void InteractionCheck()
    {
        switch (ID)
        {
            case "upgradeStation":
                print("Upgrade station");
                UpgradeStation();
                break;
            case "npc_1":
                print("npc 1");
                // Add NPC 1 specific interaction code here
                break;
            case "npc_2":
                print("npc 2");
                // Add NPC 2 specific interaction code here
                break;
            default:
                print("Unknown interaction ID");
                break;
        }
    }

    private void UpgradeStation()
    {
        upgradesUI.SetActive(true);
        isUpgrading = true; 
    }

    private void CloseUpgradeUI()
    {
        upgradesUI.SetActive(false);
        isUpgrading = false; 
    }
}
