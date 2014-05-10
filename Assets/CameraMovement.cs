using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float CamSpeed;
	public int GUISize;

	private float sinus;
	private float cosinus;


	// Use this for initialization
	void Start () {
		CamSpeed = 1.5f;
		GUISize = 20;
		FocusPlayer();
	}
	
	// Update is called once per frame
	void Update () {
		LimitCamera();
		var recdown = new Rect (0, 0, Screen.width, GUISize);
		var recup = new Rect (0, Screen.height - GUISize, Screen.width, GUISize);
		var recleft = new Rect (0, 0, GUISize, Screen.height);
		var recright = new Rect (Screen.width - GUISize, 0, GUISize, Screen.height);

		if (recdown.Contains (Input.mousePosition)) 
		{
			transform.Translate(0, 0, -CamSpeed, Space.World);
		}
		if (recup.Contains (Input.mousePosition)) 
		{
			transform.Translate(0, 0, CamSpeed, Space.World);
		}
		if (recleft.Contains (Input.mousePosition)) 
		{
			transform.Translate(-CamSpeed, 0, 0, Space.World);
		}
		if (recright.Contains (Input.mousePosition)) 
		{
			transform.Translate(CamSpeed, 0, 0, Space.World);
		}

		//Whenever the key is pressed down and HELD (Unlike "Input.GetKeyDown(KeyCode.Space)")
		if (Input.GetKey (KeyCode.Space)) 
		{
			FocusPlayer();
		}
	}

	private void LimitCamera()
	{
		if (transform.position.z <= -80) 
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, -80);		
		}
		if (transform.position.z >= 30) 
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, 30);		
		}
		if (transform.position.x <= -35) 
		{
			transform.position = new Vector3(-35, transform.position.y, transform.position.z);		
		}
		if (transform.position.x >= 35) 
		{
			transform.position = new Vector3(35, transform.position.y, transform.position.z);		
		}
	}

	private void FocusPlayer()
	{
		//Sinus and cosinus calculations of the camera angle
		sinus = Mathf.Sin ((Mathf.PI / 180) * transform.eulerAngles.x);
		cosinus = Mathf.Cos ((Mathf.PI / 180) * transform.eulerAngles.x);
		
		GameObject player = GameObject.Find("Player");
		
		//Used for determining the distance between camera and player on Z dimension
		float cameraBias = transform.position.y / Mathf.Abs(sinus / cosinus);
		transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z-cameraBias); 
	}
}
