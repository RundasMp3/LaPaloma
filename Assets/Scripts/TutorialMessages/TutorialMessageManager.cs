using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMessageManager : MonoBehaviour {

    public Text instruction;

    public Animator animator;

    // Use this for initialization
    void Start()
    {

    }

    public void StartDialogue(string instruction)
    {
        Debug.Log("Showing dialog");

        animator.SetBool("IsOpen", true);

        this.instruction.text = instruction;

        // Wait for 5 seconds then end dialogue
        StartCoroutine(WaitForTime());
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSecondsRealtime(5);
        EndDialogue();
    }

    void EndDialogue()
    {
        Debug.Log("Ending dialogue!");

        animator.SetBool("IsOpen", false);
    }

    //void Update()
    //{
        
    //}
}
