using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent navMesh;

    private WeaponSwitcher weaponSwitch;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private int health = 2;

    [SerializeField]
    private EnemyRoomTrigger enemyDoorController;

    private ZoneController zoneController;

    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        zoneController = GameObject.FindObjectOfType<ZoneController>();
        weaponSwitch = GameObject.FindObjectOfType<WeaponSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyDoorController.shouldActivate)
            navMesh.destination = player.transform.position;

        if(health <= 0)
		{
            zoneController.enemiesKilled++;
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            //health--;

            //rifle
            if (weaponSwitch.currentGunID == 0)
            {
                health -= 2;
            }
            //pistol
            else if (weaponSwitch.currentGunID == 1)
            {
                health--;
            }
        }
    }
}
