using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour {

	[SerializeField]
	private List<CharacterDisplay> chats;

	public void openChat(CharacterDisplay characterDisplay) {
		foreach (CharacterDisplay chat in chats) {
			if (chat == (characterDisplay)) {
                chat.SetActive();
			} else {
                chat.SetInactive();
            }
		}
	}
}
