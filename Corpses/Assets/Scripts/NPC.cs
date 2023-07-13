using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// //Jaina
public class NPC : MonoBehaviour
{
    public bool canInteract = false;
    public DialogueManager dialogueManager;
    public DialogueTrigger trigger;
    public bool dialogueStarted = false;

    public GameObject dialogueCanvas;
    public TMP_Text shopkeeperText;

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E) && dialogueStarted == false) //Press E to interact with NPC
        {
            dialogueStarted = true;
            // dialogueCanvas.SetActive(true);
            trigger.StartDialogue();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true;
            shopkeeperText.text = "Interact [E]";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
            shopkeeperText.text = "";
            //dialogueCanvas.SetActive(false);
        }
    }
}
