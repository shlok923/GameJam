using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textComponent;
    [SerializeField] private GameObject pressEnter;
    [SerializeField] public string[] lines;
    [SerializeField] private float textSpeed = 0.3f;

    private int index;


    // Singleton instance
    private static Dialogue instance;

    // Public property to access the instance
    public static Dialogue Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Dialogue>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(Dialogue).Name);
                    instance = singletonObject.AddComponent<Dialogue>();
                }
            }

            return instance;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (textComponent.text == lines[index])
        {
            pressEnter.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
                pressEnter.SetActive(false);
            }

            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                pressEnter.SetActive(true);
            }
        }
    }

    public void StartDialogue()
    {
        gameObject.SetActive(true);

        textComponent.text = string.Empty;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text =  string.Empty;
            StartCoroutine(TypeLine());
        }

        else
        {
            gameObject.SetActive(false);
        }
    }

}
