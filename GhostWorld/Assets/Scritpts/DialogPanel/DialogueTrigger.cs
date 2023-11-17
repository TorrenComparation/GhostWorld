using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;


    public void DialogueMaker()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
