using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeMuteButton : MonoBehaviour {
	public Sprite Mute;
	public Sprite Desmute;
	public Sprite MuteHL;
	public Sprite DesmuteHL;
	private SpriteState ST;
	private SpriteState ST2;
	private bool AlreadyMuted;

	void Update (){
		if (AudioListener.pause) {
			this.GetComponent<Image> ().sprite = Desmute;
			this.GetComponent<Button> ().spriteState = ST2;
		} else {
			this.GetComponent<Image> ().sprite = Mute;
			this.GetComponent<Button> ().spriteState = ST;
		}
	}

	void Awake (){
		ST.highlightedSprite = MuteHL;
		ST2.highlightedSprite = DesmuteHL;
	}


}
