using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Dialogue
{
    public string Name;
    // public Sprite Portrait;
    [TextArea(1,6)] //limit of text Area
    public string[] Sentences;

}
