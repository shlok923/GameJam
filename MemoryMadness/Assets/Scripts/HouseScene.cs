using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScene : MonoBehaviour
{
    [SerializeField] private Dialogue prelogue;
    private string[] preloguelines = { "Where am I?", "I don't remember anything...", "That frame? {Press E to interact}" };
    // Start is called before the first frame update
    void Start()
    {
        prelogue.lines = preloguelines;
        prelogue.StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Prelogue()
    {
        
    }
}
