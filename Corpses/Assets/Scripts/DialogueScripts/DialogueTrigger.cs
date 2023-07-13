using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using TMPro;

// Jaina 
public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    public GameObject dialogueCanvas;
    public NPC npc;

    public TMP_Text shopkeeperText;

    public void StartDialogue()
    {
        if (npc.canInteract == true)
        {
            dialogueCanvas.SetActive(true);
            FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
            shopkeeperText.text = "";
        }
    }
}

[System.Serializable]
public class DialogueSet
{
    public int actorId;
    public string messages;
}

[System.Serializable]
public class Message
{
    public int dialogueId;
    public int nextDialogueId;
    public int dialogueSetId;
    public string currentSpeaker;
    public string leftSpeaker;
    public string rightSpeaker;
    public string leftImage;
    public string rightImage;
    public string dialogueText;
    public string choices;
    internal int actorId;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}
