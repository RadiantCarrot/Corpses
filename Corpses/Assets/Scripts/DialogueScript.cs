using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript
{
    public int dialogueId { get; }
    public int nextDialogueId { get; }
    public int dialogueSetId{ get; }
    public string currentSpeaker { get; }
    public string leftSpeaker { get; }
    public string rightSpeaker { get; }
    public string leftImage { get; }
    public string rightImage { get; }
    public string dialogueText { get; }
    public string choices { get; }

    //public string name { get; }


    public DialogueScript (int dialogueId, int nextDialogueId, int dialogueSetId,
        string currentSpeaker, string leftSpeaker, string rightSpeaker, string leftImage, 
        string rightImage, string dialogueText, string choices/*, string name*/)
    {
        this.dialogueId = dialogueId;
        this.nextDialogueId = nextDialogueId;
        this.dialogueSetId = dialogueSetId;
        this.currentSpeaker = currentSpeaker;
        this.leftSpeaker = leftSpeaker;
        this.rightSpeaker = rightSpeaker;
        this.leftImage = leftImage;
        this.rightImage = rightImage;
        this.dialogueText = dialogueText;
        this.choices = choices;
        //this .name = name;
    }
    public DialogueScript(int dialogueId, int nextDialogueId, string currentSpeaker, string leftSpeaker, string rightSpeaker, string leftImage, string rightImage, string dialogueText, string choices/*, string name*/)
    {
        // Constructor implementation
    }
}
