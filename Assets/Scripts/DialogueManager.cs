using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> dialogueLines;
    private Queue<Dialogue.Faces> faces;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator PrincessAnimator;
    public Animator DialogueAnimator;
    void Start()
    {
        dialogueLines= new Queue<string>();
        faces = new Queue<Dialogue.Faces>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        DialogueAnimator.SetBool("Open", true);
        nameText.text = dialogue.name;
        dialogueLines.Clear();
        faces.Clear();
        for (int i = 0; i < dialogue.sentences.Count; i++)
        {
            dialogueLines.Enqueue(dialogue.sentences[i]);
            faces.Enqueue(dialogue.faces[i]);
        }
        
        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (dialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }
        string line = dialogueLines.Dequeue();
        StopAllCoroutines();
        Dialogue.Faces face = faces.Dequeue();

        if (face == Dialogue.Faces.smile)
        {
            PrincessAnimator.SetBool("smile", true);
            PrincessAnimator.SetBool("fun", false);
        }
        else if (face == Dialogue.Faces.fun)
        {
            PrincessAnimator.SetBool("fun", true);
            PrincessAnimator.SetBool("smile", false);
        }
        else
        {
            PrincessAnimator.SetBool("smile", false);
            PrincessAnimator.SetBool("fun", false);
        }

        StartCoroutine(TypeSentence(line));
    }

    IEnumerator TypeSentence (string type)
    {
        dialogueText.text = "";
        foreach (char letter in type.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(0.03f);
        }
    }
    public void EndDialogue()
    {
        PrincessAnimator.SetBool("smile", false);
        PrincessAnimator.SetBool("fun", false);
        DialogueAnimator.SetBool("Open", false);
    }

}
