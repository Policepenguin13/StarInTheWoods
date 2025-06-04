using UnityEngine;

public class QuestMenu : MonoBehaviour
{
    // public Quest quest;
    // public Player player;
    public GameObject questWindow;

    public GameObject questZero;
    public GameObject questOne;
    public GameObject questTwo;
    public GameObject questThree;
    public GameObject questFour;
    public GameObject questFive;

    // or have like a public array and ForEach element in questArray,
    // gameObjectArray.getcomponent<tmpro> = element.Title + " (" + Player.Inventory[element.item].ToString() + " / " + element.Amount.ToString() + ")"

    public void ShowQuestWindow()
    {
        questWindow.SetActive(true);

    }
}
