using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string name;
    [TextArea(1,3)]
    public string[] sometext;
    public float textSpeed;

    public int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = String.Empty;
        TriggerDialogAccept();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == sometext[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = sometext[index];
            }
        }
    }

    void TriggerDialogAccept()
    {
        index = 0;
        FindObjectOfType<DialogueManager>().StartDialogue(this);
        // Typeline();
    }

    public void NextLine()
    {
        if (index < sometext.Length - 1)
        {
            index++;
            textComponent.text = String.Empty;
            StartCoroutine(Typeline());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


    public IEnumerator Typeline()
    {
        foreach (char symbol in sometext[index].ToCharArray())
        {
            textComponent.text += symbol;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
