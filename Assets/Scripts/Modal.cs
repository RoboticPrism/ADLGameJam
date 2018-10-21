using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modal : MonoBehaviour {

    [SerializeField]
    Button button;

	// Use this for initialization
	void Start () {
        button.onClick.AddListener(() => CloseModal());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CloseModal ()
    {
        this.gameObject.SetActive(false);
    }
}
