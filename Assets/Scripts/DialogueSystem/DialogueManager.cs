using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    private GameObject player;
    private GroundMovement ground;

    public Text nameText;
    public Text dialogueText;
    public Image characterImage;

    public Animator animator;

    private Queue<Sentence> sentences;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ground = player.GetComponent<GroundMovement>();

        sentences = new Queue<Sentence>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        ground.enabled = false;
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
        ground.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && animator.GetBool("IsOpen"))
            DisplayNextSentence();
    }
}
