using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Jaina
public class DialogueManager : MonoBehaviour
{
    public Image actorImage1;
    public Image actorImage2;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform dialogueBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    int activeName = 0;
    public static bool isActive = false;

    public GameObject dialogueCanvas;
    public NPC npc; //SCRIPT

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        activeName = 0;
        isActive = true;

        Debug.Log("Started Conversation! Loaded messages:" + messages.Length);
        DisplayMessage();
    }
    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.dialogueText;
        Message nameToDisplay = currentMessages[activeMessage];
        actorName.text = nameToDisplay.currentSpeaker;

        //int actorId = messageToDisplay.actorId;
        //if (actorId >= 0 && actorId < currentActors.Length)
        //{
        //    Actor actorToDisplay = currentActors[actorId];
        //    actorName.text = actorToDisplay.name;
        //    Debug.Log(actorToDisplay);
        //    //actorImage1.sprite = actorToDisplay.sprite;
        //    //actorImage2.sprite = actorToDisplay.sprite;
        //}
        //else
        //{
        //    Debug.LogError("Invalid actorId: " + actorId);
        //}
    }
    public void NextMessage()
    {
        activeMessage++;
        if(activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation ended!");
            isActive = false;
            dialogueCanvas.SetActive(false);
            npc.dialogueStarted = false;
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isActive == true)
        {
            NextMessage();
        }
    }
}

