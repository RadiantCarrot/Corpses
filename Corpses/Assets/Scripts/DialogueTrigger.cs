using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jaina - Dialogue Trigger Script (1/7/2023)
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
public class Message
{
    public int actorId;
    public string message;
}
[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}
