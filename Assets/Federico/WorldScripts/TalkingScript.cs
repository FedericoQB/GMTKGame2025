using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalTalkingGuyVar
{
    public static bool talking = false;
}

[System.Serializable]
public class DialogueLine
{
    [TextArea]
    public string text;
    public float typingSpeed = 0.05f;
    public float displayDuration = 2f;
}

public class TalkingScript : MonoBehaviour
{
    public TextMeshProUGUI testText;

    [SerializeField]
    private List<DialogueLine> initialDialogueLines = new List<DialogueLine>();

    private Queue<DialogueLine> dialogueQueue = new Queue<DialogueLine>();
    private Coroutine dialogueCoroutine;

    public Action OnDialogueFinished;
    public Action<bool> OnNewLineStarted;

    public bool isDialogueActive { get; private set; } = false;

    private bool isPlayerTurn = true;

    private void Start()
    {
        if (initialDialogueLines.Count > 0)
        {
            StartDialogue(initialDialogueLines);
        }
    }

    public void StartDialogue(List<DialogueLine> dialogueLines)
    {
        if (GlobalTalkingGuyVar.talking)
            return;

        dialogueQueue.Clear();

        foreach (DialogueLine line in dialogueLines)
        {
            dialogueQueue.Enqueue(line);
        }

        dialogueCoroutine = StartCoroutine(PlayDialogue());
    }

    private IEnumerator PlayDialogue()
    {
        GlobalTalkingGuyVar.talking = true;
        isDialogueActive = true;
        isPlayerTurn = true;

        while (dialogueQueue.Count > 0)
        {
            DialogueLine line = dialogueQueue.Dequeue();

            // Notify new line start, pass who's speaking
            OnNewLineStarted?.Invoke(isPlayerTurn);

            yield return StartCoroutine(TypeText(line));
            yield return new WaitForSeconds(line.displayDuration);

            // Alternate speaker for next line
            isPlayerTurn = !isPlayerTurn;
        }

        testText.text = "";
        GlobalTalkingGuyVar.talking = false;
        isDialogueActive = false;

        OnDialogueFinished?.Invoke();
    }

    private IEnumerator TypeText(DialogueLine line)
    {
        testText.text = "";

        for (int i = 0; i < line.text.Length; i++)
        {
            testText.text += line.text[i];
            yield return new WaitForSeconds(line.typingSpeed);
        }
    }
}
