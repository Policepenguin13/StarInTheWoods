using System;
using TMPro;
using UnityEngine;

public class questUI : MonoBehaviour
{
    // like the InventoryUI script, keeps the quest UI up to date
    // :D

    public GameObject[] things;
    // 0 = until starfall
    // 1 = stars collected
    // 2 = quest 1
    // 3 = quest 2
    // 4 = quest 3

    // public GameObject[] quests;

    public Player player;

    public int icount = 0;
    public int questcount = 0;
    int InventoryAmount = 00;
    int QuestAmount = 00;
    public string item;

    // Update is called once per frame
    void Update()
    {
        icount = 0;
        questcount = 0;
        InventoryAmount = 00;
        QuestAmount = 00;
        // item = player.QuestList[questcount];
        // Debug.Log("ITEM = " + item.ToString());
        foreach (GameObject thing in things)
        {
            // Debug.Log("THING EQUALS " + thing.ToString());
            if (icount == 0)
            {
                thing.GetComponent<TextMeshProUGUI>().text = player.StarfallCounter.ToString() + "/3 Quests until Starfall";
                // Debug.Log("Starfall counter updated");
            }
            else if (icount == 1)
            {
                thing.GetComponent<TextMeshProUGUI>().text = player.Inventory["STARS"].ToString() + "/3 Stars collected";
                // Debug.Log("Star collection updated");
            }
            else if (icount >= 2)
            {
                // Debug.Log("icount (" + icount.ToString() + ") greater than 2");
                bool proceed = true;
                try
                {
                    item = player.QuestList[questcount]; // something something outside of range thing?
                }
                catch (ArgumentOutOfRangeException) 
                {
                    // Debug.Log("there was an argument out of range exception, aka the quest doesn't exist");
                    thing.GetComponent<TextMeshProUGUI>().text = "  ";
                    proceed = false;
                    
                }
                if (proceed)
                {
                    // Debug.Log("QUEST EXISTS!");
                    // Debug.Log("item = " + item);
                    InventoryAmount = player.Inventory[item.ToUpper()];
                    // Debug.Log("inventory amount =" + InventoryAmount.ToString());
                    QuestAmount = player.Quests[item];
                    // Debug.Log("quest amount = " + QuestAmount.ToString());

                    thing.GetComponent<TextMeshProUGUI>().text = "Find " + item.ToLower() + "  (" + InventoryAmount.ToString() + " / " + QuestAmount.ToString() + ")";
                }
                
                questcount += 1;
                // Debug.Log("questcount = " + questcount.ToString());
            }

            icount+=1;
            // Debug.Log("icount = " + icount.ToString());
        }
    }
}
