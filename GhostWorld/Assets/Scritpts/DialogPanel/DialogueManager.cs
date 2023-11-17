using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    private PlayerMoving playerMove;

    private void Start()
    {
        sentences = new Queue<string>();
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoving>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        playerMove.isCanMove = false;

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    private void EndDialogue() 
    {
        animator.SetBool("IsOpen", false);
        playerMove.isCanMove = true;
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char latter in sentence.ToCharArray())
        {
            dialogueText.text += latter;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
