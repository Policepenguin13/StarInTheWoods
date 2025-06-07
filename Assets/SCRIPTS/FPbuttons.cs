using UnityEngine;

public class FPbuttons : MonoBehaviour
{
    // This script controls the player's interactions with buttons,
    // like pressing Interact or the button to open their Inventory

    InputSystem_Actions controls;

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

    void InteractNext()
    {
        Debug.Log("INTERACT NEXT HAS BEEN PERFORMED");
        // In this code, if there's already something happening (like dialogue),
        // it will continue forward in that dialogue or accept the quest, OR if a thing
        // isn't happening, it will check if interactable things are in range, and
        // initiate dialogue/interaction if they are
    }

    void Quest()
    {
        Debug.Log("quest previous action performed");
        // this code will open the quest menu
    }

    void Inventory()
    {
        Debug.Log("Inventory Action Was Just Performed");
        // this code will open the inventory menu
    }

    void Close()
    {
        Debug.Log("Close performed");
        // this will skip dialogue or deny the quest or close the inventory
        // if any of those things are happening at the moment
    }
}
