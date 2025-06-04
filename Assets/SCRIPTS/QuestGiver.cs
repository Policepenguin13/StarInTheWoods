using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class QuestGiver : MonoBehaviour
{
    public Quest questToGive;
    public GameObject player;

    public GameObject questPopup;
    public GameObject questName;
    private TextMeshPro nameText;

    private void Awake()
    {
        nameText = questName.GetComponent<TextMeshPro>();
    }

    // to access Player script, player.findComponentofType<Player> i think

    // change Amount. At first it's 5, then 10, then 20
    public void ShowQuestWindow()
    {
        questPopup.SetActive(true);
        nameText.text = questToGive.Title;
        Debug.Log("Quest popup opened");
    }

    public void AcceptQuest()
    {
        questPopup.SetActive(false);
        questToGive.IsActive = true;
        // Give player the quest
        Debug.Log("Quest gets given to players here");
        //player.GetComponent<Player>().Quests;
    }
}
