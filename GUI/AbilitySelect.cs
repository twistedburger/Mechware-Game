using UnityEngine;
using System.Collections;

public class AbilitySelect : MonoBehaviour {

	public int toolbarInt = -1;
	public Texture[] NoAbilitiesSelected, Ability1Selected, Ability2Selected, Ability3Selected, Ability4Selected, currentToolbarTexture;
	public string currentAbility;
	
	void Start() {
		currentToolbarTexture = NoAbilitiesSelected;
	}

	void Update() {
		if (toolbarInt == 0 || Input.GetKeyDown(KeyCode.Alpha1)) {
			currentToolbarTexture = Ability1Selected;
			toolbarInt = 0;
			currentAbility = "Big Bonk";
		}
		
		if (toolbarInt == 1 || Input.GetKeyDown(KeyCode.Alpha2)) {
			currentToolbarTexture = Ability2Selected;
			toolbarInt = 1;
			currentAbility = "Paralyzing Poke";
		}

		if (toolbarInt == 2 || Input.GetKeyDown (KeyCode.Alpha3)) {
			currentToolbarTexture = Ability3Selected;
			toolbarInt = 2;
			currentAbility = "Super Slam";
		
		}

		if (toolbarInt == 3 || Input.GetKeyDown (KeyCode.Alpha4)) {
			currentToolbarTexture = Ability4Selected;
			toolbarInt = 3;
			currentAbility = "Spin Cycle";
		
		}
	}


	void OnGUI() {
		GUI.backgroundColor = Color.clear;
		toolbarInt = GUI.Toolbar(new Rect(25, 25, 250, 30), toolbarInt, currentToolbarTexture);
	}
}