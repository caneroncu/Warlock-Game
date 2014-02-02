using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

	public NavMeshAgent nav;
	public Transform target;

	RaycastHit hit;

	// Use this for initialization
	void Start () {
		nav.angularSpeed = 0; //To prevent the player from trying to turn around
		nav.acceleration = 15; //Acceleration
		nav.speed = 5; //Maximum speed
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (nav.speed < 12) {
			nav.speed += 0.0005f; //For making it harder to control character as the game moves on
		}

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) //Converting mouse position on screen to 3d vector
		{
			if (hit.collider.name == "TerrainMain") //Name of the floor Plane
			{
				if (Input.GetMouseButtonDown(1)){ //If right click
					target.position = hit.point;
				}
			}		
		}
		nav.destination = target.position; //Player's destination is targer's position

		if (Input.GetKeyDown (KeyCode.Space)) { //Fun shit. You be pressing...
			nav.Warp(target.position); 			//...you be trippin
		}
	}

}
