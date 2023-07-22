using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Done by Jaina
public class DialogueScript
{
    public int dialogueId { get; }
    public int nextDialogueId { get; }
    public int dialogueSetId{ get; }
    public string currentSpeaker { get; }
    public string leftImage { get; }
    public string rightImage { get; }
    public string dialogueText { get; }

    public DialogueScript (int dialogueId, int nextDialogueId, int dialogueSetId,
        string currentSpeaker, string leftImage, 
        string rightImage, string dialogueText)
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
