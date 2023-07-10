using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kar Lonng
public class DialogueScript
{
    public string dialogueId { get; }
    public string displayName { get; }
    public Sprite displaySprite { get; }
    public string dialogueText { get; }

    public DialogueScript (string dialogueId, string displayName, Sprite displaySprite, string dialogueText)
    {
        this.dialogueId = dialogueId;
        this.displayName = displayName;
        this.displaySprite = displaySprite;
        this.dialogueText = dialogueText;
    }
}
