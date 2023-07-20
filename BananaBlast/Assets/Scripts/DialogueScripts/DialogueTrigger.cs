using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Done by Jaina
public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    public GameObject dialogueCanvas;
    public NPC npc;

    public TMP_Text shopkeeperText;

    public WeaponFreezerScript weaponFreezerScript;
    public PlayerMoveScript playerMoveScript;


    public void StartDialogue()
    {
        Time.timeScale = 0;
        weaponFreezerScript.weaponFreeze = true;
        playerMoveScript.flipFreeze = true;

        if (npc.isShopkeeper == false) // if NPC is tutorial NPC
        {
            List<DialogueScript> dialogueList = DataAccessScript.GetDialogueBySetId(1001);
            List<Message> messageList = new List<Message>();

            foreach (DialogueScript dialogue in dialogueList)
            {
                Message newMessage = new Message(dialogue.dialogueId, dialogue.nextDialogueId, dialogue.dialogueSetId, dialogue.currentSpeaker, dialogue.leftImage, dialogue.rightImage, dialogue.dialogueText);
                messageList.Add(newMessage);
            }

            messages = messageList.ToArray();
        }

        else // if NPC is shopkeeper
        {
            List<DialogueScript> dialogueList = DataAccessScript.GetDialogueBySetId(1002);
            List<Message> messageList = new List<Message>();

            foreach (DialogueScript dialogue in dialogueList)
            {
                Message newMessage = new Message(dialogue.dialogueId, dialogue.nextDialogueId, dialogue.dialogueSetId, dialogue.currentSpeaker, dialogue.leftImage, dialogue.rightImage, dialogue.dialogueText);
                messageList.Add(newMessage);
            }

            messages = messageList.ToArray();
        }

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
    public string leftImage;
    public string rightImage;
    public string dialogueText;
    internal int actorId;

    public Message (int dialogueId, int nextDialogueId, int dialogueSetId, string currentSpeaker, string leftImage, string rightImage, string dialogueText)
    {
        this.dialogueId = dialogueId;
        this.nextDialogueId = nextDialogueId;
        this.dialogueSetId = dialogueSetId;
        this.currentSpeaker = currentSpeaker;
        this.leftImage = leftImage;
        this.rightImage = rightImage;
        this.dialogueText = dialogueText;
    }
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}
