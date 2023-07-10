using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;


//Jaina
public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Image actorImage2;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform DialogueBox;

    Message[] currentMessages;
    int activeMessage = 0;
    public static bool isActive = false;

    [System.Serializable]
    public class Actor : MonoBehaviour
    {
        public string name;
        public Sprite sprite;
    }

    public void OpenDialogue(DialogueSet dialogueSet)
    {
        currentMessages = dialogueSet.messages.ToArray();
        activeMessage = 0;
        isActive = true;

        Debug.Log("Started Conversation! Loaded Messages: " + currentMessages.Length);
        DisplayMessage(); // to update the UI 
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage]; // to get current text
        messageText.text = messageToDisplay.dialogueText;

        Actor actorToDisplay = GetActor(messageToDisplay.currentSpeaker); // to get current speaking character
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation ended");
            isActive = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }

    Actor GetActor(string actorName)
    {
        Actor[] actors = FindObjectsOfType<Actor>();
        foreach (Actor actor in actors)
        {
            if (actor.name == actorName)
            {
                return actor;
            }
        }
        return null;
    }
}