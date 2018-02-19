using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{

	public CharacterController cc;
	public float speed = 5.0f;
	public float gravity = 20.0f;
	public float jumpSpeed = 8.0f;

	private Vector3 moveDirection = Vector3.zero;

	private int snack;

	public Transform playerPos;


//	public Text text;

	public float distance = 10.0f;
	private float currentX = 0.0f;
	private float currentY = 0.0f;

	private float sensitivityY = 4.0f;

	// Use this for initialization
	void Start()
	{
		snack = 0;
		//text.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		//fukcing move the player
		CharacterController cc = GetComponent<CharacterController>();
		if (cc.isGrounded)
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetKeyDown(KeyCode.Space))
				moveDirection.y = jumpSpeed;
		}

		moveDirection.y -= gravity * Time.deltaTime;
		cc.Move(moveDirection * Time.deltaTime);


		//make camera follow ur mouse
		float newRotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityY;

		gameObject.transform.localEulerAngles = new Vector3(0, newRotationY, 0);
	}
}

