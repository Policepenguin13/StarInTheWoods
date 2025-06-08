using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // when player is in range and presses a specific button,
    // check if NPC's quest is active and if they have Amount of Item to complete quest
    // determines which FindChild("talk questInactive/Active/Finished").MyDialogue" is DialogueTrigger's dialogue
    // getcomponent DialogueTrigger.TriggerDialogue

    public GameObject talk;
    MyDialogue talkies;
    public GameObject player;
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
            // Debug.Log("next sentence");
            manager.DisplayNextSentence();
        } // else if (manager.sentences.Count == 0) {
          //  Debug.Log("sentence count 0, end of dialogue?");
          //  player.GetComponent<FPmove>().CanMove = true;
          //  Debug.Log("movement enabled");
        //}
        else
        {
            manager.StartDialogue(talkies, this.gameObject);
            manager.AmTalking = true;
            player.GetComponent<FPmove>().CanMove = false;
            // Debug.Log("movement disabled");
        }
    }

    public void Close()
    {
        Debug.Log("stop / skip dialogue!!");
    }

    public void DialogueEnded()
    {
        player.GetComponent<FPmove>().CanMove = true;
        // Debug.Log("movement enabled");

        // add quest here
    }
}
