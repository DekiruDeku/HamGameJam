using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> _sentences;
    public Text NameText;
    public Text DialogueSentences;
    // public GameObject Portrait;

    void Start()
    {
        _sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log($"Start a conversation with {dialogue.Name}.");
        NameText.text = dialogue.Name;
        // Portrait = dialogue.Portrait;
        _sentences.Clear();

        foreach (var text in dialogue.Sentences) //Can upgrade wih second foreach to do a load of letters, keep it in mind
        {
            _sentences.Enqueue(text);
            
        }
        DisplayNextSentences();
    }

    public void DisplayNextSentences() //Add many ways to continue a dialogue
    {
        if(_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) ||
            Input.GetMouseButtonDown(0)) // space,enter,left click
        {
            string sentence = _sentences.Dequeue();
            DialogueSentences.text = sentence;
            Debug.Log(sentence);
        }
    }

    private void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}
