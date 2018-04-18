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
    /// The current expression shown in the dialogue box. IGNORE FOR NOW
    /// </summary>
    //public Character.Expression currentExpression;

    /// <summary>
    /// The current character's expression. Just for the time being.
    /// </summary>
    public Sprite characterExpression;

    /// <summary>
    /// The speaking character's name. Just for the time beinb.
    /// </summary>
    public string characterName;

    /// <summary>
    /// The Character that is saying this sentence.
    /// </summary>
    //public Character speaker;

    /// <summary>
    /// If true, the dialogue box will shake a bit.
    /// </summary>
    bool isYelled = false;
}


