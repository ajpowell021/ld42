using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractions : MonoBehaviour {

	// Public Functions

	public Item getNewCounterItem(Item itemOne, Item itemTwo) {

		if (theseItems(itemOne, itemTwo, Item.DOG, Item.MICROWAVE_OFF)) {
			return Item.MICROWAVE_COOKING;
		}

		if (theseItems(itemOne, itemTwo, Item.BUN, Item.BREADBOX)) {
			return Item.BREADBOX;
		}

		if (theseItems(itemOne, itemTwo, Item.DOG, Item.FRIDGE)) {
			return Item.FRIDGE;
		}

		if (theseItems(itemOne, itemTwo, Item.COOKED_DOG, Item.BUN)) {
			return Item.HOTDOG_WITH_BUN;
		}

		if (theseItems(itemOne, itemTwo, Item.HOTDOG_WITH_BUN, Item.KETCHUP)) {
			return Item.HOTDOG_BUN_W_KETCHUP;
		}

		if (theseItems(itemOne, itemTwo, Item.HOTDOG_WITH_BUN, Item.MUSTARD)) {
			return Item.HOTDOG_BUN_W_MUSTARD;
		}

		if (theseItems(itemOne, itemTwo, Item.HOTDOG_WITH_BUN, Item.RELISH_JAR)) {
			return Item.HOTDOG_RELISH;
		}

		Debug.Log("No interection");

		// This is bad right now, cause it basically deletes whats there...
		return Item.NONE;
	}

	// Private Functions

	private static bool theseItems(Item compareOne, Item compareTwo, Item checkOne, Item checkTwo) {
		return compareOne == checkOne && compareTwo == checkTwo
		       || compareOne == checkTwo && compareTwo == checkOne;
	}


}
