using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// //Jaina 
public class NPC : MonoBehaviour
{
    public bool canInteract = true;
    public DialogueManager dialogueManager;
    public DialogueTrigger trigger;
    public bool dialogueStarted = false;

    public GameObject dialogueCanvas;

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E) && dialogueStarted == false) //Press E to interact with NPC
        {
            dialogueStarted = true;
            //dialogueCanvas.SetActive(true);
            trigger.StartDialogue();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
            //dialogueCanvas.SetActive(false);
        }
    }
}
