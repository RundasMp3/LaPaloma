using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// DEPRECATED, won't be used unless it's truly needed.
/// A container class for a character's info to be used in a dialogue.
/// </summary>
[System.Serializable]
public class Character {

    /// <summary>
    /// The available expressions for a character to have in a dialogue box.
    /// </summary>
    public enum Expression { normal, worried, thinking, angry, surprised, blushing };

    /// <summary>
    /// The name of the Character that is speaking.
    /// </summary>
    public string name;

    /// <summary>
    /// An array of all of the speaking Character's expressions
    /// </summary>
    public Image[] expressions;
    
}
