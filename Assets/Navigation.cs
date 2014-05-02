using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

	public NavMeshAgent nav;
	public Transform target;

	RaycastHit hit;

	public string names=string.Empty;
	public string names2=string.Empty;

	// Use this for initialization
	void Start () {
		nav.angularSpeed = 500; 
		nav.acceleration = 50; //Acceleration
		nav.speed = 9; //Maximum speed
		nav.baseOffset = nav.transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Determining the NavMesh Layer the player is on
		int floorMask = 1 << NavMesh.GetNavMeshLayerFromName ("Floor");
		NavMeshHit nHit;
		nav.SamplePathPosition (-1, 0.0f, out nHit);

		if ((nHit.mask & floorMask) != 0)
		{
			names = "Walkin in da hood";
		}
		else
		{
			names = "AW SHIT!";
		}
		//Determining the NavMesh Layer the player is on


		if (nav.speed < 10) {
			nav.speed +=  0.005f/17.5f; //For making it harder to control character as the game progesses
		}

		if (nav.acceleration >= 15) {
			nav.acceleration -= 0.005f; //For making it harder to control character as the game progesses
		}


		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) //Converting mouse position on screen to 3d vector
		{
			if (hit.collider.name == "TerrainMain" || hit.collider.name == "TerrainLava") //Name of the floor Plane
			{
				if (Input.GetMouseButtonDown(1)){ //If right click
					//target.position = hit.point;
					Vector3 newPos = new Vector3(hit.point.x, hit.point.y + target.localScale.y/2, hit.point.z);
					target.position=newPos;
				}
			}		
		}
		nav.destination = target.position; //Player's destination is targer's position


		if (Input.GetKeyDown (KeyCode.Space)) { //Fun shit. You be pressing...
			//nav.Warp(target.position); 			//...you be trippin
		}
	
	}

}
