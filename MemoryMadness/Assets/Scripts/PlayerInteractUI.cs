using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerInteract playerInteract;
    // Start is called before the first frame update

    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    private void Show()
    {
        containerGameObject.SetActive(true);
    }

    // Update is called once per frame
    private void Hide()
    {
        containerGameObject.SetActive(false);
    }
}
