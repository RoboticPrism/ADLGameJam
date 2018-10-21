using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DialogController : MonoBehaviour {

    [SerializeField]
    Dialogues dialog;

    [Header("Prefab Connections")]

    [SerializeField]
    DialogText myDialogTextPrefab;
    [SerializeField]
    DialogText otherDialogTextPrefab;

    [SerializeField]
    TypingText myTypingTextPrefab;
    [SerializeField]
    TypingText otherTypingTextPrefab;

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
        TypingText typingTextInstance;
        yield return new WaitForSeconds(waitTime);
        if (IsSpeakerMe(dialog.GetCurrentDialogue()))
        {
            typingTextInstance = Instantiate(myTypingTextPrefab, chatWindow);
        } 
        else
        {
            typingTextInstance = Instantiate(otherTypingTextPrefab, chatWindow);
        }
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

            TextForSpeaker(dialog.GetCurrentDialogue());

            if (!dialog.End())
            {
                StartCoroutine(WaitForNextNode(0.5f, 1));
            }
        }
        else
        {
            TextForSpeaker(dialog.GetCurrentDialogue());

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

    // Determines whos speaking and makes a textbox for them
    public void TextForSpeaker(string text)
    {
        DialogText dt;
        if (IsSpeakerMe(text))
        {
            dt = Instantiate(myDialogTextPrefab, chatWindow);
        }
        else
        {
            dt = Instantiate(otherDialogTextPrefab, chatWindow);
        }
        text = text.Replace("[me]", "");
        dt.Display(text);
    }

    public bool IsSpeakerMe(string text)
    {
        return text.Contains("[me]");
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
