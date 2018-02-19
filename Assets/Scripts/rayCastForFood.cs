using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rayCastForFood : MonoBehaviour
{
	public Text text;
	
	// Use this for initialization
	void Start ()
	{
		text.enabled = false;
	}
	
	//raycast for food!
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.gameObject.tag == "Death") //if you eat a nut, yiou die
				{
					text.enabled = true;
					text.text = "you killed me thanks";
					Destroy(hit.transform.gameObject);
				}
				
				if (hit.transform.gameObject.tag == "Safe") //if you eat not a nut, you win
                {
                   text.enabled = true;
                   text.text = "you win i guess?";
                   Destroy(hit.transform.gameObject);
                 }	
			}
		}
	}
}
