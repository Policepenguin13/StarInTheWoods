using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FPbuttons : MonoBehaviour
{
    // This script controls the player's interactions with buttons,
    // like pressing Interact or the button to open their Inventory

    InputSystem_Actions controls;

    public bool NPCinRange = false;
    public bool interacting = false;

    public GameObject UI;
    public List<Transform> popups = new();

    Transform NPCinQuestion;

    private void Awake()
    {
        controls = new InputSystem_Actions();

        controls.FPactions.InteractNext.performed += ctx => InteractNext();
        controls.FPactions.Quest.performed += ctx => Quest();
        controls.FPactions.Inventory.performed += ctx => Inventory();
        controls.FPactions.Close.performed += ctx => Close();

    }
    private void OnEnable()
    {
        controls.FPactions.Enable();
    }
    private void OnDisable()
    {
        controls.FPactions.Disable();
    }

    private void Start()
    {
        foreach (Transform child in UI.transform)
        {
            popups.Add(child);
            //Debug.Log(child.name + " added to popups");


            // popups[0] = interactPopup (for when in range to interact with NPC)
            // popups[1] = newQuestPopup
            // popups[2] = new item popup
            // popups[3] = quests
            // popups[4] = inventory
        }
        foreach (Transform element in popups)
        {
            element.gameObject.SetActive(false); // hides all of them
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.ToString() + " HAS ENTERED PLAYER'S RANGE");
        if (other.CompareTag("NPC"))
        {
            NPCinRange = true;
            NPCinQuestion = other.transform;
            // Debug.Log(other.ToString() + " IS AN NPC!");
            
            if (interacting == false)
            {
                popups[0].gameObject.SetActive(true);
            }
        } else
        {
            // Debug.Log(other.ToString() + " isnt an npc, returning... (triggerEnter)");
            return;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Debug.Log(other.ToString() + " HAS LEFT PLAYER'S RANGE");
        if (other.CompareTag("NPC"))
        {
            NPCinRange = false;
            NPCinQuestion = null;
            // Debug.Log(other.ToString() + " WAS AN NPC");

            popups[0].gameObject.SetActive(false);
        }
        else
        {
            // Debug.Log(other.ToString() + " isnt an npc, returning...(triggerExit)");
            return;
        }
    }

    // Checks if NPCs are in range, starts/continues dialogue if they are
    void InteractNext()
    {

        // Debug.Log("INTERACT NEXT HAS BEEN PERFORMED");
        popups[0].gameObject.SetActive(false); // hides the popup just cause

        if (NPCinRange)
        {
            NPCinQuestion.GetComponent<NPC>().Interact();
            // interacting = true;
            // this.GetComponent<FPmove>().enabled = false;
            // Debug.Log("movement script disabled");
        }

    }

    // opens the quest menu
    void Quest()
    {
        // Debug.Log("quest action performed");
        // this.gameObject.GetComponent<Player>().UpdateQuests();
        popups[3].gameObject.SetActive(true);
    }

    // opens inventory
    void Inventory()
    {
        // Debug.Log("Inventory Action Was Just Performed");
        // this.gameObject.GetComponent<Player>().UpdateQuests();
        popups[4].gameObject.SetActive(true);
    }

    // skips dialogue or closes the inventory / quest menu
    void Close()
    {
        // calls manager's EndDialogue() ?
        popups[3].gameObject.SetActive(false);
        popups[4].gameObject.SetActive(false);
        Debug.Log("Close performed");


        // if (NPCinRange)
        // {
        //     NPCinQuestion.GetComponent<NPC>().Close();
        // }
    }
}
