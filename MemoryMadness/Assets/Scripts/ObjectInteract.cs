using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private GameObject house;
    [SerializeField] private GameObject park;
    private string[] textlines = { "The hell? What place is this?",  "Am I dreaming or something?", "Why does it feel familiar....?"};
    
    private void Start()
    {

    }
    public void Interact()
    {
        house.SetActive(false);
        park.SetActive(true);
        dialogue.lines = textlines;
        dialogue.StartDialogue();
    }
}
