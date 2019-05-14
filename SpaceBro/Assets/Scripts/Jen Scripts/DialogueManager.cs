using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public string songToStopDuring; //name of song to stop on dialogue start
    public string songToTriggerDuring; //name of song to trigger on dialogue start
    public string songToTriggerAfter; //name of song to trigger on dialogue finish

    public Animator animator;


    private Queue<Dialogue> dialogue_q;


    void Start()
    {
        dialogue_q = new Queue<Dialogue>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            DisplayNextDialogue();
        }
    }


    public void StartDialogue(Dialogue[] conversation)
    {
        //animator.SetBool("isOpen", true);

        if (songToStopDuring != "NONE"){
            FindObjectOfType<AudioManager>().Stop(songToStopDuring);
        }
        if (songToTriggerDuring != "NONE"){
            FindObjectOfType<AudioManager>().Play(songToTriggerDuring);
        }

        dialogue_q.Clear();

        foreach(Dialogue dialogue in conversation)
        {
            dialogue_q.Enqueue(dialogue);
        }

        DisplayNextDialogue();
    }

    public void DisplayNextDialogue()
    {
        if (dialogue_q.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue dialogue = dialogue_q.Dequeue();
        nameText.text = dialogue.name;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogue.sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        //animator.SetBool("isOpen", false);

        if (songToTriggerDuring != "NONE"){
            FindObjectOfType<AudioManager>().Stop(songToTriggerDuring);
        }
        if (songToTriggerAfter != "NONE"){
            FindObjectOfType<AudioManager>().Play(songToTriggerAfter);
        }
    }


}
