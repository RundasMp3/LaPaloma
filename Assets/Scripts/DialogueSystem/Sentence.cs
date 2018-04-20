using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sentence {
    
    /// <summary>
    /// The sentence.
    /// </summary>
    public string text;

    /// <summary>
    /// The current character's expression.
    /// </summary>
    public Sprite characterExpression;

    /// <summary>
    /// The speaking character's name. 
    /// </summary>
    public string characterName;

    /// <summary>
    /// If true, the dialogue box will shake a bit.
    /// </summary>
    public bool isYelled = false;
}


