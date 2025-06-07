using UnityEngine;

public class NPC : MonoBehaviour
{
    // when player is in range and presses a specific button,
    // check if NPC's quest is active and if they have Amount of Item to complete quest
    // determines which FindChild("talk questInactive/Active/Finished").MyDialogue" is DialogueTrigger's dialogue
    // getcomponent DialogueTrigger.TriggerDialogue

    public GameObject talk;
    MyDialogue talkies;
    DialogueManger manager; // it was at this point that i realised i'd misspelled "manager". This is fine.

    private void Start()
    {
        talkies = GetComponentInChildren<MyDialogue>();
        manager = FindFirstObjectByType<DialogueManger>();
    }

    public void Interact()
    {
        if (manager.AmTalking)
        {
            manager.DisplayNextSentence();
        }
        else
        {
            manager.StartDialogue(talkies);
        }
    }

}
