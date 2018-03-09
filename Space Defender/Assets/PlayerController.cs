using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Camera cam;
	Vector3 mousePos;
	Vector2 pos;

	public Texture2D crosshair;
	[SerializeField] float rotSpeed;
	[SerializeField] float moveSpeed;

	void Start () {
		Cursor.SetCursor(crosshair, Vector2.zero, CursorMode.Auto);
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);	//Get the mouse position in terms of the world (i.e. transform.position)
		Vector3 pos = transform.position;	//Get the position of the ship
	 	float angleRad = Mathf.Atan2(mousePos.y - pos.y, mousePos.x - pos.x);	//Get the angle between the ship and the mouse (in radians)
        float angleDeg = (180 / Mathf.PI) * angleRad;	//Convert the angle to degrees
		// Rotate Object
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angleDeg), rotSpeed * Time.deltaTime);

		pos = transform.position;
		pos += moveSpeed * transform.right * Time.deltaTime * Input.GetAxisRaw("Vertical");
		transform.position = pos;
	}
}
