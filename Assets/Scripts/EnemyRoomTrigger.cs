using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomTrigger : MonoBehaviour
{
	[System.NonSerialized]
	public bool shouldActivate;

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			shouldActivate = true;
		}
	}
}
