using UnityEngine;
[System.Serializable]
public class DialogueTrigger : MonoBehaviour
{
    public MyDialogue dialogue;

    public void TriggerDialogue()
    {
        FindFirstObjectByType<DialogueManger>().StartDialogue(dialogue);
    }
}
