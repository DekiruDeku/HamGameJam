using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> _sentences;
    public Text NameTextFieldInCanvas;
    public Text TextFieldInCanvas;

    public Animator animator;
    // public GameObject Portrait;

    void Start()
    {
        _sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log($"Start a conversation with {dialogue.Name}.");
        NameTextFieldInCanvas.text = dialogue.Name;
        // Portrait = dialogue.Portrait;
        _sentences.Clear();

        animator.SetBool("IsOpen", true);

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

        string sentence;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter)) // space,enter
        {
            sentence = _sentences.Dequeue();
            TextFieldInCanvas.text = sentence;
            Debug.Log(sentence);
        }
        //if hit a button
        sentence = _sentences.Dequeue();
        StopAllCoroutines(); //this need if we need to the next sentence this stop previosuly
        StartCoroutine(TypeSentence(sentence));
        Debug.Log(sentence);
    }

    private IEnumerator TypeSentence(string sentence)
    {
        TextFieldInCanvas.text = "";
        foreach (var letters in sentence.ToCharArray())
        {
            TextFieldInCanvas.text += letters;
            yield return null; //time to write a symbol
        }
    }

    private void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation");
    }
}
