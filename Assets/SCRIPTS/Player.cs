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
    // This script handles all the inventory and quest stuff

    public int TotalQuestsCompleted = 0;
    // every interval of 3, starfall!
    
    // public int Stars = 0;
    // public int UntilNextStarfall = 0;

    //public Array Quests;
    //public List<Quest> Quests = new List<Quest>();

    public Dictionary<string, int> Quests = new();
    public List<Transform> questGivers = new();

    public Dictionary<string, int> Inventory = new();

    private float timer = 0f;
    private bool timerOn = false;

    private void Start()
    {
        Inventory.Clear();

        Inventory.Add("STARS", 0);
        Inventory.Add("BERRIES", 0);        
        Inventory.Add("FLOWERS", 0);
        Inventory.Add("MUSHROOMS",0);

        Quests.Clear();
        questGivers.Clear();
    }

    public void AddItemToInventory(string item, int amount)
    {
        Inventory[item] += amount;
        Debug.Log(Inventory[item].ToString() + " " + item + " GATHERED!");
        TextMeshProUGUI words = GetComponent<FPbuttons>().popups[2].GetComponent<TextMeshProUGUI>();
        words.text = "+ " + amount.ToString() + " " + item.ToUpper() + "!";
        this.gameObject.GetComponent<FPbuttons>().popups[2].gameObject.SetActive(true);
        timerOn = true;
        timer += 3f;
        // words = FPbuttons.popups[2].GetComponent<TextMeshProUGUI>();
        // words.text = "+ " + amount.ToString() + " " + item.ToUpper() + "!";
    }

    private void TimesUp()
    {
        this.gameObject.GetComponent<FPbuttons>().popups[2].gameObject.SetActive(false);
        timer = 0f;
    }

    private void Update()
    {
        if (timerOn)
        {
            timer -= Time.deltaTime;
        } if (timer <= 0.0) 
        {
            TimesUp();
            timerOn = false;
        }
    }

    public void AddQuest(string item, int goalamount, Transform provider)
    {
        Quests.Add(item, goalamount);
        // Quests.ToArray();
        Debug.Log(Quests.ToString());
        questGivers.Add(provider);
        Debug.Log(questGivers.ToString());
        // int giverNumber = questGivers.IndexOf(provider);
        // Debug.Log(provider.name.ToUpper() + "'s quest is at index" + giverNumber.ToString());
        return;
        // list transform QuestGivers 
    }

    public void UpdateQuests()
    {
        Debug.Log("Oopsies no quests rn");
    }
}
