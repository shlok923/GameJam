using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private GameObject end;
    [SerializeField] private GameObject player;
    [SerializeField] private Dialogue dialogue;
    private string[] textlines = { "That....is mine..." };
    // using physics
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 3f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out ObjectInteract objectInteract))
                {
                    if (objectInteract.CompareTag("Cycle"))
                    {
                        dialogue.lines = textlines;
                        dialogue.StartDialogue();
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        end.SetActive(true);
                    } 
                    objectInteract.Interact();
                }
            }
        }
    }

    public ObjectInteract GetInteractableObject()
    {
        float interactRange = 3f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out ObjectInteract objectInteract))
            {
                return objectInteract;
            }
        }
        return null;
    }
}
