using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditScreenController : MonoBehaviour {

	[System.Serializable]
	public class CreditItem {
		public string area;
		public string[] names;
	}

	public int currentItem = 0;
	public bool loop = true;
	public CreditItem[] items;
	public Text areaText;
	public Text authorsText;

	public void Start() {
		AddInfoToTheTexts ();
	}

	public void ShowNextItem() {
		currentItem++;
		if (currentItem >= items.Length) {
			if (loop)
				currentItem = 0;
			else
				SceneManager.LoadScene ("MainMenu");
		}

		AddInfoToTheTexts ();
	}

	public void AddInfoToTheTexts() {
		areaText.text = items [currentItem].area;

		string names = "";
		for (int i = 0; i < items [currentItem].names.Length; ++i) {
			names += items [currentItem].names [i] + "\n";
		}

		authorsText.text = names;
	}

	public void Update() {
		if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
			SceneManager.LoadScene ("MainMenu");
	}


}
