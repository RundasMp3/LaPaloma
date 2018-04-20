using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMessageTrigger : MonoBehaviour {

    /// <summary>
    /// The instruction to be displayed.
    /// </summary>
    [TextArea(1, 3)]
    public string instruction;

    private bool hasBeenShown = false;

    public void TriggerDialogue()
    {
        if (!hasBeenShown)
        {
            hasBeenShown = true;
            FindObjectOfType<TutorialMessageManager>().StartDialogue(instruction);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered!");
        TriggerDialogue();
    }
}
