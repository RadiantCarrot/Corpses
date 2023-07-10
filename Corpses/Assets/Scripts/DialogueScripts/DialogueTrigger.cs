using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

// Jaina
public class DialogueTrigger : MonoBehaviour
{
    public DialogueSet dialogueSet;

    public void StartDialogue()
    {
        string json = JsonConvert.SerializeObject(dialogueSet);
        dialogueSet = JsonConvert.DeserializeObject<DialogueSet>(json);
        FindObjectOfType<DialogueManager>().OpenDialogue(dialogueSet);
    }
}

[System.Serializable]
public class DialogueSet
{
    public List<Message> messages;
    public List<Actor> actors;
}

[System.Serializable]
public class Message
{
    public string dialogueId;
    public string nextDialogueId;
    public string dialogueSetId;
    public string currentSpeaker;
    public string leftSpeaker;
    public string rightSpeaker;
    public string leftImage;
    public string rightImage;
    public string dialogueText;
    public string choices;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}