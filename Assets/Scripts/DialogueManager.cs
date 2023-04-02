using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log($"Start dialogue with {dialogue.name}");
        
        sentences.Clear();
        dialogue.Typeline();
    }
    
    public void NextLine(Dialogue dialogue)
    {
        
    }
}
