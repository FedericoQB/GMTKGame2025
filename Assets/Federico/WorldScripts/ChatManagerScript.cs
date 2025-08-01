using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManagerScript : MonoBehaviour
{
    public GameObject playerTextBox;
    public GameObject mysteryTextBox;
    public TalkingScript talkingScript;

    private void Start()
    {
        if (talkingScript != null)
        {
            // Subscribe to line start and end callbacks
            talkingScript.OnNewLineStarted += OnNewLineStarted;
            talkingScript.OnDialogueFinished += OnDialogueEnd;
        }

        // Ensure both boxes are off initially
        playerTextBox.SetActive(false);
        mysteryTextBox.SetActive(false);
    }

    private void OnNewLineStarted(bool isPlayerSpeaking)
    {
        //  Show the correct speaker's text box
        if (isPlayerSpeaking)
        {
            playerTextBox.SetActive(true);
            mysteryTextBox.SetActive(false);
        }
        else
        {
            playerTextBox.SetActive(false);
            mysteryTextBox.SetActive(true);
        }
    }

    private void OnDialogueEnd()
    {
        // Hide both boxes when the dialogue finishes
        playerTextBox.SetActive(false);
        mysteryTextBox.SetActive(false);
    }
}
