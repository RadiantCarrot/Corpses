using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Jaina 
public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
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
