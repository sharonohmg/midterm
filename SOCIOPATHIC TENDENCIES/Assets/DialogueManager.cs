using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {


    public Text dialogueText;
    public Queue<string> sentences;
    public Animator animator;
    public Animator animator2;
    public Animator animator3;

    // Use this for initialization
    void Start () {
        sentences = new Queue<string>();
        animator.SetBool("Close", false);
        animator2.SetBool("nextOn", false);
        animator3.SetBool("nextOn", false);
    }
	

    public void StartDialogue (Dialogue dialogue){

        animator.SetBool("Close", true);
        animator2.SetBool("nextOn", true);
        animator3.SetBool("nextOn", true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }


    public void DisplayNextSentence(){

        if (sentences.Count == 0){

            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence){
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue(){
        animator2.SetBool("nextOn", false);
    }

}
