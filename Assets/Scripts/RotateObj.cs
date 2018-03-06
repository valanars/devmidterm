using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
	public Transform killme;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Pickup()
	{
		transform.position = new Vector3(0, 5, 0);
	}
}
