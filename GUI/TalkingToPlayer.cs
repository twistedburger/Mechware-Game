using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;


public class TalkingToPlayer : MonoBehaviour {
	
	
	public float disBeforeNotice;
	public Texture speechBox;
	public Font myFont;
	public string fileName;
	public int saying;

	private GameObject player, parent;
	private Sprite talkingSprite;
	private float heightThatWorks =1.57f, height;
	private GUIStyle mine;
	
	public bool speech = false;
	private string[] viewableWhatImSaying;
	private int whatLineImSaying = 0;

	private string[] allSayings;

	
	// Use this for initialization
	void Start () {
		if (disBeforeNotice == 0) {
			disBeforeNotice = 3;		
		}

		allSayings = load (fileName);
		viewableWhatImSaying = parseString (allSayings[saying]);


		player = GameObject.Find ("Player");
		talkingSprite = GetComponent<SpriteRenderer> ().sprite;
		GetComponent<SpriteRenderer> ().sprite = null;
		
		mine = new GUIStyle ();
		mine.font = myFont;
		mine.normal.textColor = Color.red;
		

	}
	
	// Update is called once per frame
	void Update () {

		// See if the player is around
		if (!speech && (player.transform.position - transform.parent.position).magnitude < disBeforeNotice) {
			GetComponent<SpriteRenderer> ().sprite = talkingSprite;
			
			if(Input.GetKeyDown(KeyCode.T)) {
				viewableWhatImSaying = parseString (allSayings [saying]);
				GetComponent<SpriteRenderer> ().sprite = null;
				speech = true;			
			}
		} else 
			GetComponent<SpriteRenderer> ().sprite = null;
		
		// Determine what's being said, and if there's nothing left, you're done talking
		if(speech && Input.GetKeyDown(KeyCode.Space)) {
			whatLineImSaying++;
		}
		
		if (whatLineImSaying == viewableWhatImSaying.Length) {
			speech = false;
			whatLineImSaying = 0;
		}
	}



















	void OnGUI() {
		if(speech == true) {
			GUI.DrawTexture(new Rect (0, 0.75f*Screen.height, Screen.width, 0.25f*Screen.height), speechBox);
			GUI.Box(new Rect (0.1f*Screen.width, 0.75f*Screen.height + 0.04f*Screen.height, 0, height - 0.04f*Screen.height), viewableWhatImSaying[whatLineImSaying], mine);
			GUI.Box(new Rect (0.1f*Screen.width, 0.9f*Screen.height, 0, 10), "Space to continue", mine);
		}
		
	}

	// Parses strings into sizes big enough for the computer to see
	
	string[] parseString(string str) {
											
		
		float charsOnScreenTemp = (Screen.width * 68f / 717f + 4.61f);
		int charsOnScreen = Mathf.FloorToInt (charsOnScreenTemp);
		string[] stringArr = new string[Mathf.CeilToInt(str.Length/charsOnScreenTemp)];
		
								
		
		ArrayList myArr = new ArrayList (str.ToCharArray());
		char[] tempArr = new char[charsOnScreen];
		
									
			
		
		int temp = 0;
		while (myArr.Count > 0) {
			
			int arraySizes;
			
			if(myArr.Count > charsOnScreen)
				arraySizes = charsOnScreen;
			else
				arraySizes = myArr.Count;
			
			string tempString = "";
			object[] tempArr2 = myArr.ToArray();
			
											
			
			for(int i = 0; i < arraySizes; i++) {
											
				tempArr[i] = tempArr2[i].ToString().ToCharArray()[0];
				myArr.RemoveAt(0);
				tempString += "" + tempArr[i];
				tempArr.SetValue(null,i);
			}
			myArr.TrimToSize();
			stringArr[temp] = tempString;
			
										
			
			temp++;
			
		}
		
		for (int i = 0; i < stringArr.Length; i++) {
			
													
			
		}
		return stringArr;
	}

	private string[] load(string fileName) {
		string line;
		StreamReader reader = new StreamReader (fileName, Encoding.Default);
		line = reader.ReadToEnd ();
		return line.Split ('\n');
	}
}