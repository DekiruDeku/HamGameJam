using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteract : MonoBehaviour
{
    public DialogueTrigger _trigger;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _trigger.TriggerOfDialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
