using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.UIElements;
using TMPro;
// using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // This script handles the player-side inventory and quest stuff

    public int TotalQuestsCompleted = 0;
    public int StarfallCounter = 0;
    // every interval of 3, starfall!
    
    // public int Stars = 0;
    // public int UntilNextStarfall = 0;

    //public Array Quests;
    //public List<Quest> Quests = new List<Quest>();

    public Dictionary<string, int> Quests = new();
    // public List<Transform> questGivers = new();
    public List<string> QuestList = new();

    public Dictionary<string, int> Inventory = new();

    private float ItemTimer = 0f;
    private bool ItemTimerOn = false;
    private float QuestTimer = 0f;
    private bool QuestTimerOn = false;

    private void Start()
    {
        Inventory.Clear();

        Inventory.Add("STARS", 0);
        Inventory.Add("BERRIES", 0);        
        Inventory.Add("FLOWERS", 0);
        Inventory.Add("MUSHROOMS",0);

        Quests.Clear();
        // questGivers.Clear();
    }

    public void AddItemToInventory(string item, int amount)
    {
        Inventory[item] += amount;
        // Debug.Log(Inventory[item].ToString() + " " + item + " GATHERED!");

        TextMeshProUGUI words = GetComponent<FPbuttons>().popups[2].GetComponent<TextMeshProUGUI>();
        if (amount < 0)
        {
            words.text = amount.ToString() + " " + item.ToUpper() + "!";
        }
        else
        {
            words.text = "+ " + amount.ToString() + " " + item.ToUpper() + "!";
        }
        this.gameObject.GetComponent<FPbuttons>().popups[2].gameObject.SetActive(true);
        ItemTimerOn = true;
        ItemTimer = 3f;
        // words = FPbuttons.popups[2].GetComponent<TextMeshProUGUI>();
        // words.text = "+ " + amount.ToString() + " " + item.ToUpper() + "!";
    }

    private void ItemTimesUp()
    {
        this.gameObject.GetComponent<FPbuttons>().popups[2].gameObject.SetActive(false);
        ItemTimer = 0f;
    }
    private void QuestTimesUp()
    {
        this.gameObject.GetComponent<FPbuttons>().popups[1].gameObject.SetActive(false);
        QuestTimer = 0f;
    }

    private void Update()
    {
        if (ItemTimerOn)
        {
            ItemTimer -= Time.deltaTime;
            if (ItemTimer < 0.0)
            {
                ItemTimesUp();
                ItemTimerOn = false;
            }
        }
        if (QuestTimerOn)
        {
            QuestTimer -= Time.deltaTime;
            if (QuestTimer < 0.0)
            {
                QuestTimesUp();
                QuestTimerOn = false;
            }
        }
    }

    public void AddQuest(string item, int goalamount) //Transform provider)
    {
        Quests.Add(item, goalamount);
        // string ele = item;
        QuestList.Add(item);

        Debug.Log("Added " + item + " " + goalamount.ToString() + " to quests");

        //Debug.Log(QuestList.ToString());
        //Debug.Log(Quests.ToString());

        this.gameObject.GetComponent<FPbuttons>().popups[1].gameObject.SetActive(true);
        QuestTimerOn = true;
        QuestTimer = 3f;

        // questGivers.Add(provider);
        // Debug.Log(questGivers.ToString());
        // int giverNumber = questGivers.IndexOf(provider);
        // Debug.Log(provider.name.ToUpper() + "'s quest is at index" + giverNumber.ToString());
        // return;
        // list transform QuestGivers 
    }

    public void RemoveQuest(string item)
    {
        Quests.Remove(item);
        Debug.Log("Removed " + item + " from quests");
        QuestList.Remove(item);

        // Debug.Log("Removed " + item + " from quest list, questlist now = " + QuestList.ToString());
        TotalQuestsCompleted += 1;
        StarfallCounter += 1;
        if (StarfallCounter > 3)
        {
            StarfallCounter = 0;
            // call starfall here
        }
    }
}
