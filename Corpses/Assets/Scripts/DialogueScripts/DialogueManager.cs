using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Jaina
public class DialogueManager : MonoBehaviour
{
    public Image actorImage1;
    public Image actorImage2;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform dialogueBox;

    Message[] currentMessages;
    string[] currentMessage;
    Actor[] currentActors;
    int activeMessage = 0;
    int activeName = 0;
    public static bool isActive = false;

    public GameObject dialogueCanvas;
    public NPC npc; //NPC SCRIPT

    public GameObject playerAvatar;
    public GameObject shopkeeperAvatar;
    public GameObject tutorialNpcAvatar;

    public TMP_Text shopkeeperText;

    public WeaponFreezerScript weaponFreezerScript;
    public PlayerMoveScript playerMoveScript;


    void Start()
    {

    }


    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        activeName = 0;
        isActive = true;



        //Debug.Log("Started Conversation! Loaded messages:" + messages.Length);
        DisplayMessage();
    }
    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.dialogueText;
        //messageText.text = currentMessage[activeMessage];
        Message nameToDisplay = currentMessages[activeMessage];
        actorName.text = nameToDisplay.currentSpeaker;

        if (nameToDisplay.currentSpeaker == "Player")
        {
            shopkeeperAvatar.GetComponent<Image>().color = Color.grey;
            playerAvatar.GetComponent<Image>().color = Color.white;
        }

        else
        {
            shopkeeperAvatar.GetComponent<Image>().color = Color.white;
            playerAvatar.GetComponent<Image>().color = Color.grey;
        }

        //int actorid = messagetodisplay.actorid;
        //if (actorid >= 0 && actorid < currentactors.length)
        //{
        //    actor actortodisplay = currentactors[actorid];
        //    actorname.text = actortodisplay.name;
        //    debug.log(actortodisplay);
        //    //actorimage1.sprite = actortodisplay.sprite;
        //    //actorimage2.sprite = actortodisplay.sprite;
        //}
        //else
        //{
        //    debug.logerror("invalid actorid: " + actorid);
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
            //Debug.Log("Conversation ended!");
            Time.timeScale = 1;
            weaponFreezerScript.weaponFreeze = false;
            playerMoveScript.flipFreeze = false;
            isActive = false;
            dialogueCanvas.SetActive(false);
            npc.dialogueStarted = false;
            shopkeeperText.text = "";
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isActive == true)
        {
            NextMessage();
            FindObjectOfType<AudioManager>().Play("DialogueClick");
        }
    }
}

