using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Script : MonoBehaviour
{
    //All using variables
    public GameObject canvas;
    public bool Interact_Bool = false;
    private bool isPlayerInRange = false;

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
            canvas.SetActive(false);
        }
    }

    private void Update()
    {
        //IF E is pressed and player is in range run interaction Event
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            InteractionEvent();
        }
    }

    public void Toggle()
    {
        if (!Interact_Bool)
        {
            canvas.SetActive(true);
        }
    }

    public void InteractionEvent()
    {
        //Put your interaction event here!!
        print("Yay you interacted");
    }
}
