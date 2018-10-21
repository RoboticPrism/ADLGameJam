using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DialogController : MonoBehaviour {

    [SerializeField]
    Dialogues dialog;

    [Header("Prefab Connections")]

    [SerializeField]
    DialogText dialogTextPrefab;

    [SerializeField]
    TypingText typingTextPrefab;

    [Header("Instance Connections")]

    [SerializeField]
    RectTransform chatWindow;

    [SerializeField]
    DialogChoice dialogChoice1Instance;
    [SerializeField]
    DialogChoice dialogChoice2Instance;
    [SerializeField]
    DialogChoice dialogChoice3Instance;

    // Use this for initialization
    void Start () {
        dialog.SetTree("Test1");
        Display();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Step to the next node and rerender
    void NextNode()
    {
        dialog.Next();
        Display();
    }

    // Wait some time before doing the next node
    public IEnumerator WaitForNextNode(float waitTime, float textTime)
    {
        yield return new WaitForSeconds(waitTime);
        TypingText typingTextInstance = Instantiate(typingTextPrefab, chatWindow);
        yield return new WaitForSeconds(textTime);
        Destroy(typingTextInstance.gameObject);
        NextNode();
    }

    // Refreshes the UI
    void Display()
    {
        if(dialog.GetChoices().Length == 0)
        {
            dialogChoice1Instance.Display();
            dialogChoice2Instance.Display();
            dialogChoice3Instance.Display();

            DialogText dt = Instantiate(dialogTextPrefab, chatWindow);
            dt.Display(dialog.GetCurrentDialogue());

            if (!dialog.End())
            {
                StartCoroutine(WaitForNextNode(0.5f, 1));
            }
        }
        else
        {
            DialogText dt = Instantiate(dialogTextPrefab, chatWindow);
            dt.Display(dialog.GetCurrentDialogue());

            dialogChoice1Instance.Display(dialog.GetChoices()[0], MakeChoice1);
            if (dialog.GetChoices().Length > 1)
            {
                dialogChoice2Instance.Display(dialog.GetChoices()[1], MakeChoice2);
            }
            if (dialog.GetChoices().Length > 2)
            {
                dialogChoice3Instance.Display(dialog.GetChoices()[2], MakeChoice3);
            }
        }
    }

    // Makes a selection
    public void MakeChoice(int selection)
    {
        dialog.NextChoice(dialog.GetChoices()[selection]);
        Display();
    }

    void MakeChoice1()
    {
        MakeChoice(0);
    }

    void MakeChoice2()
    {
        MakeChoice(1);
    }

    void MakeChoice3()
    {
        MakeChoice(2);
    }
}
