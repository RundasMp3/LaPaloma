using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;
    public Image characterImage;

    public Animator animator;

    private Queue<Sentence> sentences;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<Sentence>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting dialogue!");

        animator.SetBool("IsOpen", true);


        sentences.Clear();

        foreach (Sentence sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        Sentence currentSentence = sentences.Dequeue();

        nameText.text = currentSentence.characterName;
        characterImage.sprite = currentSentence.characterExpression;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence.text));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("Ending dialogue!");

        animator.SetBool("IsOpen", false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && animator.GetBool("IsOpen"))
            DisplayNextSentence();
    }
}
