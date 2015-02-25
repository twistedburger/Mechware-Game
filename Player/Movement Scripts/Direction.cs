using UnityEngine;
using System.Collections;

public class Direction : MonoBehaviour
{


		private int current;
		private bool pressingPrevB;

		// Use this for initialization
		void Start ()
		{
				current = 0;
				pressingPrevB = false;
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				specialsDown (Input.GetKey (KeyCode.W), Input.GetKey (KeyCode.A), Input.GetKey (KeyCode.S), Input.GetKey (KeyCode.D));
				pressingPrev (Input.GetKey (KeyCode.W), Input.GetKey (KeyCode.A), Input.GetKey (KeyCode.S), Input.GetKey (KeyCode.D));
		}

		void specialsDown (bool w, bool a, bool s, bool d)
		{
				if (!pressingPrevB) {
						if (w)
								current = 1;
						if (a)
								current = 2;
						if (s)
								current = 3;
						if (d)
								current = 4;
				}
		}

		void pressingPrev (bool w, bool a, bool s, bool d)
		{

				if (w && current == 1) 
						pressingPrevB = true;
				if (a && current == 2)
						pressingPrevB = true;
				if (s && current == 3)
						pressingPrevB = true;
				if (d && current == 4)
						pressingPrevB = true;
				if (current == 1 && !w)
						pressingPrevB = false;
				if (current == 2 && !a)
						pressingPrevB = false;
				if (current == 3 && !s)
						pressingPrevB = false;
				if (current == 4 && !d)
						pressingPrevB = false;
				if (!w && !a && !s && !d)
						pressingPrevB = false;
		}

		public int GetDirection ()
		{
				return current;
		}

		public bool IsMoving ()
		{
				return pressingPrevB;
		}
}
