using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("General")]
    public GameObject mainCamera;
	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump")){
			jump = true;
		}

		if (Input.GetButtonDown("Crouch")){
			Debug.Log("Crouch");
			crouch = true;
		} else if (Input.GetButtonUp("Crouch")){
			crouch = false;
		}

	}

	void FixedUpdate (){
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;

		//update camera position to follow player
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
	}
}
