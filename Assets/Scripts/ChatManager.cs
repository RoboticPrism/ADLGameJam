using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour {

	[SerializeField]
	private List<GameObject> chats;

	public void openChat(GameObject thisChat) {
		foreach (GameObject chat in chats) {
			if (chat == (thisChat)) {
				thisChat.SetActive (true);
			} else {
				chat.SetActive (false);
			}
		}
	}


}
