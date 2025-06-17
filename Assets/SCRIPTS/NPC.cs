using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // when player is in range and presses a specific button,
    // check if NPC's quest is active and if they have Amount of Item to complete quest
    // determines which FindChild("talk questInactive/Active/Finished").MyDialogue" is DialogueTrigger's dialogue
    // getcomponent DialogueTrigger.TriggerDialogue

    public List<Transform> Talks = new();

    MyDialogue talkies;

    public GameObject player;
    DialogueManger manager; // it was at this point that i realised i'd misspelled "manager". This is fine.

    public string Item;
    public int FirstQuestAmount;
    public int SecondQuestAmount;
    public int ThirdQuestAmount;

    string QuestStatus = "Inactive";

    int QuestsForThisNPC = 0;

    private void Start()
    {
        // talkies = Talks[3].GetComponent<MyDialogue>();

        foreach (Transform option in this.transform)
        {
            if (option.gameObject.GetComponent<MyDialogue>() != null)
            {
                Talks.Add(option);
            }
            
            // option.GetComponent<MyDialogue>();

            // 0 = GiveFirstQuest
            // 1 = GiveQuest
            // 2 = QuestInProgress
            // 3 = AllQuestsDone
            // 4 = SubmittingQuest
        }
        manager = FindFirstObjectByType<DialogueManger>();
        QuestsForThisNPC = 0;
    }

    public void Interact()
    {
        if (manager.AmTalking)
        {
            // Debug.Log("next sentence");
            manager.DisplayNextSentence();
        }
        else
        {
            // check value/amount of Item in player's inventory. If it's greater than or equal to
            // [First/Second/Third]QuestAmount (depending on QuestsForThisNPC), access the relevant
            // dialogues to complete the quest. If QuestsForThisNPC == 0, then it's fine

            if (QuestsForThisNPC == 0) // done no quests for this NPC before
            {
                // Debug.Log("player has done 0 quests for this NPC");

                if (player.GetComponent<Player>().Quests.ContainsKey(Item)) // has the quest
                {
                    // Debug.Log("player has the quest");
                    if (player.GetComponent<Player>().Inventory[Item] < FirstQuestAmount) // not enough items
                    {
                        talkies = Talks[2].GetComponent<MyDialogue>(); // Quest in Progress
                        // Debug.Log("player doesn't have enough items");
                    }
                    else
                    {
                        talkies = Talks[4].GetComponent<MyDialogue>(); // Quest submitting
                        // Debug.Log("player has enough items, submit quest!!");
                        QuestStatus = "Submitting";
                    }
                }
                else // doesn't have the quest
                {
                    // Debug.Log("player doesn't have the quest!");
                    talkies = Talks[0].GetComponent<MyDialogue>(); // Give first quest
                    QuestStatus = "Giving";
                }
            }
            else if (QuestsForThisNPC == 1) // done 1 quest for this NPc before
            {
                // Debug.Log("player has done 1 quest for this NPC");

                if (player.GetComponent<Player>().Quests.ContainsKey(Item)) // has the quest
                {
                    // Debug.Log("player has the quest");
                    if (player.GetComponent<Player>().Inventory[Item] < SecondQuestAmount) // not enough items
                    {
                        talkies = Talks[2].GetComponent<MyDialogue>(); // Quest in Progress
                        // Debug.Log("player doesn't have enough items");
                    }
                    else
                    {
                        talkies = Talks[4].GetComponent<MyDialogue>(); // Quest submitting
                        // Debug.Log("player has enough items, submit quest!!");
                        QuestStatus = "Submitting";
                    }
                }
                else // doesn't have the quest
                {
                    // Debug.Log("player doesn't have the quest!");
                    talkies = Talks[1].GetComponent<MyDialogue>(); // Give 2nd quest
                    QuestStatus = "Giving";
                }
            }
            else if (QuestsForThisNPC == 2) // done 2 quest for this NPC before
            {
                // Debug.Log("player has done 2 quests for this NPC");

                if (player.GetComponent<Player>().Quests.ContainsKey(Item)) // has the quest
                {
                    // Debug.Log("player has the quest");
                    if (player.GetComponent<Player>().Inventory[Item] < ThirdQuestAmount) // not enough items
                    {
                        talkies = Talks[2].GetComponent<MyDialogue>(); // Quest in Progress
                        // Debug.Log("player doesn't have enough items");
                        QuestStatus = "Inactive";
                    }
                    else
                    {
                        talkies = Talks[4].GetComponent<MyDialogue>(); // Quest submitting
                        // Debug.Log("player has enough items, submit quest!!");
                        QuestStatus = "Submitting";
                    }
                }
                else // doesn't have the quest
                {
                    // Debug.Log("player doesn't have the quest!");
                    talkies = Talks[1].GetComponent<MyDialogue>(); // Give 3rd quest
                    QuestStatus = "Giving";
                }
            }
            else
            {
                // Debug.Log("player has completed all quests for this NPC");
                talkies = Talks[3].GetComponent<MyDialogue>();
                QuestStatus = "Inactive";
            }

            manager.StartDialogue(talkies, this.gameObject);
            manager.AmTalking = true;
            player.GetComponent<FPmove>().CanMove = false;
            player.GetComponent<FPbuttons>().interacting = true;
            // Debug.Log("movement disabled");
        }
    }

    public void DialogueEnded()
    {
        player.GetComponent<FPmove>().CanMove = true;
        // Debug.Log("movement enabled");

        player.GetComponent<FPbuttons>().interacting = false;
        

        if (QuestStatus == "Giving") // player.GetComponent<Player>().Quests.ContainsKey(Item) == false)
        {
            // Debug.Log("NPC is adding quest");
            if (QuestsForThisNPC == 0)
            {
                player.GetComponent<Player>().AddQuest(Item, FirstQuestAmount);
            }
            else if (QuestsForThisNPC == 1)
            {
                player.GetComponent<Player>().AddQuest(Item, SecondQuestAmount);
            }
            else if (QuestsForThisNPC == 2)
            {
                player.GetComponent<Player>().AddQuest(Item, ThirdQuestAmount);
            }
        }
        else if (QuestStatus == "Submitting")
        {
            // Debug.Log("NPC's quest has already been added");
            player.GetComponent<Player>().RemoveQuest(Item);
            if (QuestsForThisNPC == 0)
            {
                player.GetComponent<Player>().AddItemToInventory(Item, -FirstQuestAmount);
            }
            else if (QuestsForThisNPC == 1)
            {
                player.GetComponent<Player>().AddItemToInventory(Item, -SecondQuestAmount);
            }
            else
            {
                player.GetComponent<Player>().AddItemToInventory(Item, -ThirdQuestAmount);
            }

            QuestsForThisNPC += 1;
        }
        // else { Debug.Log("quest status is none"); }
        // player.GetComponent<Player>().AddQuest()

    }
}
