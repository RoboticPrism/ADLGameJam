using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour {

    [SerializeField]
    Image image;
    [SerializeField]
    Button button;

    [SerializeField]
    DialogController dialogController;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetActive ()
    {
        dialogController.transform.localScale = Vector3.one;
        button.image.color = new Color(1f, 1f, 1f, 1f);
    }

    public void SetInactive ()
    {
        dialogController.transform.localScale = Vector3.zero;
        button.image.color = new Color(1f, 1f, 1f, 0.5f);
    }
}
