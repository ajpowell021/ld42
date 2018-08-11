using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderPanelManager : MonoBehaviour {

	public Text panelOneText;
	public Text panelTwoText;
	public Text panelThreeText;

	public GameObject panelOne;
	public GameObject panelTwo;
	public GameObject panelThree;

	private void Start() {
		hidePanel(1);
		hidePanel(2);
		hidePanel(3);
	}

	public void setOrderText(int position, Item item) {
		string orderText;

		switch (item) {

			case Item.HOTDOG_WITH_BUN:
				orderText = "Plain Hotdog w/ Bun";
				break;
			case Item.COOKED_DOG:
				orderText = "Plain Hotdog, hold the bun";
				break;
			case Item.HOTDOG_BUN_W_KETCHUP:
				orderText = "Hotdog with ketchup";
				break;
			case Item.HOTDOG_BUN_W_MUSTARD:
				orderText = "Hotdog with mustard";
				break;
			case Item.HOTDOG_K_AND_M:
				orderText = "Hotdog with ketchup and mustard.";
				break;
			default:
				Debug.Log("Wrong item type.");
				orderText = "error";
				break;
		}

		if (position == 1) {
			panelOneText.text = orderText;
		}
		else if (position == 2) {
			panelTwoText.text = orderText;
		}
		else {
			panelThreeText.text = orderText;
		}
	}

	public void showPanel(int position) {
		switch (position) {

			case 1:
				panelOne.GetComponent<RectTransform>().position = new Vector3(2.4f, 1.3f, .5f);
				break;
			case 2:
				panelTwo.GetComponent<RectTransform>().position = new Vector3(5f, 1.3f, .5f);
				break;
			case 3:
				panelThree.GetComponent<RectTransform>().position = new Vector3(7.5f, 1.3f, .5f);
				break;
		}
	}

	public void hidePanel(int position) {
		switch (position) {

			case 1:
				panelOne.GetComponent<RectTransform>().position = new Vector3(2.4f, 1.3f, -5f);
				break;
			case 2:
				panelTwo.GetComponent<RectTransform>().position = new Vector3(5f, 1.3f, -5f);
				break;
			case 3:
				panelThree.GetComponent<RectTransform>().position = new Vector3(7.5f, 1.3f, -5f);
				break;
		}
	}
}
