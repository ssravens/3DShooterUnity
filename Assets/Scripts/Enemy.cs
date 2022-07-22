using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth = 1f;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float rotationSpeed = 3.4f;
    [SerializeField] private Transform weapon;
    [SerializeField] private float wDamage = 2f;
    [SerializeField] private float range = .5f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float aRate = 1.5f;
    [SerializeField] private GameObject ammoDrop;
    private GameObject player;
    private float aTime = 0f;
    private float health;
    private Rigidbody rBody;
    private Transform othrC;
    private float lookY;
    private Vector3 EulerAngleVelocity;
    private WeaponSwitcher weaponSwitch;


    // Start is called before the first frame update
    void Start()
    {
        othrC = this.gameObject.transform.GetChild(2);
        Physics.IgnoreCollision(othrC.GetComponent<Collider>(), GetComponent<Collider>(), true);
        player = GameObject.FindGameObjectWithTag("Player");
        health = maxHealth;
        rBody = GetComponent<Rigidbody>();
        //rBody.constraints = RigidbodyConstraints.FreezePositionY;
        //rBody.constraints = RigidbodyConstraints.FreezeRotationX;
        weaponSwitch = GameObject.FindObjectOfType<WeaponSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
           Death();
        }
    }

    private void FixedUpdate()
    {
        Follow();

        //if (Time.time >= aTime)
        //{
        //        Attack();
        //        aTime = Time.time + 1f / aRate;
        //}
    }

    // deals damage to enemy
    public void Damage(float dam)
    {
        health -= dam;

        if (health <= 0)
        {
            Death();
        }
    }

    // destroys enemy gameobject
    private void Death()
    {
        Destroy(gameObject);

        Instantiate(ammoDrop, transform.position, transform.rotation);
    }

    // follow the player
    private void Follow()
    {
        var playerLoc = transform.InverseTransformPoint(player.transform.position);
        lookY = Mathf.Atan2(playerLoc.x, playerLoc.z) * Mathf.Rad2Deg;
        EulerAngleVelocity = new Vector3(0, lookY, 0);
        Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity * rotationSpeed * Time.deltaTime);
        rBody.MoveRotation(rBody.rotation * deltaRotation);
        //rBody.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    // enemy attack
    private void Attack()
    {
        Collider[] hit = Physics.OverlapSphere(weapon.position, range, playerLayer);

        foreach (Collider pl in hit) 
        {
            Debug.Log("enemy attack");
            pl.GetComponent<PHealth>().Damage(wDamage);
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

    // draws attack area on the scene
    //private void OnDrawGizmosSelected()
    //{
    //    if (weapon == null) { return; }
    //    Gizmos.DrawWireSphere(weapon.position, range);
    //}
}
