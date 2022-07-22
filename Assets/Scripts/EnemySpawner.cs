using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float cooldown = 3f;
    [SerializeField] private float startDelay = 1f;
    private float timer;
    private float health = 1f;
    //private GameObject enemyC;
    private WeaponSwitcher weaponSwitch;

    private void Start()
    {
        timer = startDelay / .02f;
        //enemyC = GameObject.FindGameObjectWithTag("Enemy");
        //Physics.IgnoreCollision(enemyC.GetComponent<Collider>(), GetComponent<Collider>(), true);
        //Physics.IgnoreCollision(enemyC.transform.GetComponent<Collider>(), GetComponent<Collider>(), true);
        weaponSwitch = GameObject.FindObjectOfType<WeaponSwitcher>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (timer <= 0) 
        { 
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            timer = cooldown / .02f;
        }
        timer--;
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
