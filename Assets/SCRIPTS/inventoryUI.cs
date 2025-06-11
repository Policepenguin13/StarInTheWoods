using TMPro;
using UnityEngine;

public class inventoryUI : MonoBehaviour
{
    // This script will keep all the inventory UI up to date

    public Player player;

    public GameObject[] numbers;
    // 0 = stars
    // 1 = berries
    // 2 = flowers
    // 3 = mushrooms

    // Update is called once per frame
    void Update()
    {
        int icount = 0;
        int amount = 00;
        foreach (GameObject thing in numbers)
        {
            if (icount == 0)
            {
                amount = player.Inventory["STARS"];
                // Debug.Log("Inventory[STARS] = " + amount.ToString());
            }
            else if (icount == 1)
            {
                amount = player.Inventory["BERRIES"];
                // Debug.Log("Inventory[BERRIES] = " + amount.ToString());
            }
            else if (icount == 2)
            {
                amount = amount = player.Inventory["FLOWERS"];
                // Debug.Log("Inventory[FLOWERS] = " + amount.ToString());
            }
            else if (icount == 3)
            {
                amount = amount = player.Inventory["MUSHROOMS"];
                // Debug.Log("Inventory[MUSHROOMS] = " + amount.ToString());
            }


            if (amount > 999)
            {
                thing.GetComponent<TextMeshProUGUI>().text = "999+";
                // Debug.Log("text is 999+");
            }
            else
            {
                thing.GetComponent<TextMeshProUGUI>().text = amount.ToString();
                // Debug.Log("text is " + amount.ToString());
            }
            
            icount += 1;
            // Debug.Log("icount = " + icount.ToString());
        }
        // icount = 0;
    }
}
