using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

	public NavMeshAgent nav;
	public Transform target;

	private Vector3 RightClickPoint;

	RaycastHit hit;

	// Use this for initialization
	void Start () {
		nav.speed = 10;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) 
		{
			if (hit.collider.name == "TerrainMain") 
			{
				if (Input.GetMouseButtonDown(1)){
					target.position = hit.point;
				}
			}		
		}
		nav.destination = target.position;

		if (Input.GetKeyDown (KeyCode.Space)) {
			nav.Warp(target.position);
		}

	}

}
