using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManger : MonoBehaviour
{
    public GameObject displayName;
    public GameObject displayText;
    TextMeshProUGUI saying;
    TextMeshProUGUI NPCname;

    public Animator animator;

    private Queue<string> sentences;

    private MyDialogue convo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sentences = new Queue<string>();

        saying = displayText.GetComponent<TextMeshProUGUI>();
        NPCname = displayName.GetComponent<TextMeshProUGUI>();
    }

    public void StartDialogue(MyDialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        
        Debug.Log("Starting conversation with " + dialogue.NPCname);
        NPCname.text = dialogue.NPCname.ToUpper();
        convo = dialogue;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        // saying.text = sentence;
        // Debug.Log(sentence);
    }

    IEnumerator TypeSentence(string sentence)
    {
        saying.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            saying.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation with " + convo.name);
        animator.SetBool("IsOpen", false);
    }
}
