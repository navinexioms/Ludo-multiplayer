﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerIV_Script : MonoBehaviour {

	// Use this for initialization
	public static string GreenPlayerIV_ColName;

	void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.tag == "blocks") 
		{

			GreenPlayerIV_ColName = col.gameObject.name;

			if (col.gameObject.name.Contains ("Safe House")) 
			{

				print ("Entered PlayerI GreenI in safe house");

			}
		}
	}
	// Use this for initialization
	void Start () 
	{

		GreenPlayerIV_ColName = "none";

	}
}
