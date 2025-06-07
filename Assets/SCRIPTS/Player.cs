using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // This script handles all the inventory and quest stuff

    public int TotalQuestsCompleted = 0;
    public int Stars = 0;
    // public int UntilNextStarfall = 0;

    //public Array Quests;
    //public List<Quest> Quests = new List<Quest>();

    public Dictionary<string, int> Quests = new();

    public Dictionary<string, int> Inventory = new();

    private void Start()
    {
        Inventory.Clear();

        Inventory.Add("STARS", 0);
        Inventory.Add("BERRIES", 0);        
        Inventory.Add("FLOWERS", 0);
        Inventory.Add("MUSHROOMS",0);

        Quests.Clear();
    }

    public void AddItemToInventory(string item, int amount)
    {
        Inventory[item] += amount;
        Debug.Log(Inventory[item].ToString() + " " + item + " GATHERED!");
    }

    public void AddQuest(string item, int goalamount)
    {
        Quests.Add(item, goalamount);
        Debug.Log(Quests.ToString());
        //return i;
    }
}
