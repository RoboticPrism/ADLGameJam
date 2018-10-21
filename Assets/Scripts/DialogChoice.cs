using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogChoice : MonoBehaviour {

    [SerializeField]
    Text text;
    [SerializeField]
    Button button;

    public delegate void Action();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Updates the display on the choice
    public void Display(string message, Action action)
    {
        this.text.text = message;
        this.button.onClick.AddListener(() => action());
        button.gameObject.SetActive(true);
    }

    public void Display()
    {
        button.gameObject.SetActive(false);
    }
}
