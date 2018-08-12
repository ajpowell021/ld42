using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {


	// 1. Starts right away when scene is loaded, get hot dogs from the fridge using space bar.
	// 2. Once player is holding uncooked dog, put hotddog into one of the microwaves with space bar.
	// 3. Right after 2, get bun from bread box.
	// 4. Once microwave is finished, put dog in bun, add any condiments your customer wants.  You can pull condiments from storage on the right side of the truck if you need to.
	// 5. Once you are holding the correct hotdog, press the number key that corresponds to the customer's order number.

	// Panels

	public GameObject getHotDogPanel;
	public GameObject cookDogPanel;
	public GameObject getBunPanel;
	public GameObject condimentsPanel;
	public GameObject turnInPanel;
	public GameObject finalPanel;

	public bool getDogPanelShown;
	public bool cookDogPanelShown;
	public bool getBunPanelShown;
	public bool condimentsPanelShown;
	public bool turnInPanelShown;

	// Init

	private void Start() {
		setPanel(0, true);
	}
	
	// Public

	public void setPanel(int position, bool set) {
		switch (position) {

			case 0:
				getHotDogPanel.SetActive(set);
				break;
			case 1:
				cookDogPanel.SetActive(set);
				break;
			case 2:
				getBunPanel.SetActive(set);
				break;
			case 3:
				condimentsPanel.SetActive(set);
				break;
			case 4:
				turnInPanel.SetActive(set);
				break;
			case 5:
				finalPanel.SetActive(set);
				if (set) {
					StartCoroutine(deletePanel());
				}
				break;
			default:
				Debug.Log("wrong position for tutorial");
				break;
		}
	}

	private IEnumerator deletePanel() {
		yield return new WaitForSeconds(3);
		setPanel(5, false);
	}
}
