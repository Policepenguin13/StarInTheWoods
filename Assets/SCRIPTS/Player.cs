using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int TotalQuestsCompleted = 0;
    public int Stars = 0;
    public int UntilNextStarfall = 0;

    //public Array Quests;
    //public List<Quest> Quests = new List<Quest>();

    public Dictionary<string, int> Inventory = new();

    private void Start()
    {
        Inventory.Clear();
        Inventory.Add("MUSHROOMS",0);
        Inventory.Add("FLOWERS", 0);
        Inventory.Add("BERRIES", 0);
    }

    public void AddItemToInventory(string item)
    {
        Inventory[item] += 1;
        Debug.Log(Inventory[item].ToString() + " " + item + " GATHERED!");
    }
}
