using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public Player player;
    public GameObject questWindow;

    public GameObject questZero;
    public GameObject questOne;
    public GameObject questTwo;
    public GameObject questThree;
    public GameObject questFour;
    public GameObject questFive;

    public void ShowQuestWindow()
    {
        questWindow.SetActive(true);

    }
}
