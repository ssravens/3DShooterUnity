using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTriggerController : MonoBehaviour
{
	private ZoneController zoneController;
	
	void Awake()
	{
		zoneController = GameObject.FindObjectOfType<ZoneController>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			Debug.Log("Game Won!");
			zoneController.Win();
		}
	}
}
