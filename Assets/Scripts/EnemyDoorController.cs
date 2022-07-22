using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoorController : MonoBehaviour
{
    private bool complete;

    [SerializeField] private GameObject[] ourDoor;

    void Update()
    {
        int enemyCount = transform.childCount;

        if(enemyCount <= 0 && !complete)
		{
            //open door
            Debug.Log("Beaten Enemies");
            foreach (GameObject door in ourDoor) {
                door.SetActive(false);
            }
            complete = true;
		}
    }
}
