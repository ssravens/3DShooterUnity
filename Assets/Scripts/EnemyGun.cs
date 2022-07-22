using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField]
    EnemyBullet bullet;

    [SerializeField]
    float cooldown;

    [SerializeField]
    float bulletDamage;

    public int myWeaponID;

    public int bulletAmmo;

    public float range;

    public LayerMask playerLayer;

    [System.NonSerialized]
    public bool canShoot = true;

    //private GunController control;

	private void Awake()
	{
        //control = GameObject.FindObjectOfType<GunController>();
	}

    private void Update()
    {
        bool hit = Physics.CheckSphere(transform.position, range, playerLayer);

        if (hit && canShoot)
        {
            Fire();
        }
    }
    public void Fire()
    {
        if (bulletAmmo >= 1)
            if (canShoot) 
            {
                canShoot = false;
                bulletAmmo--; 
                StartCoroutine(Bulletcooldown());
                Vector3 pos = transform.forward;
                Vector3 bulletDir = transform.forward;
                EnemyBullet test = Instantiate(bullet, this.transform.position, Quaternion.identity);
                test.transform.LookAt(Camera.main.transform);
                test.damage = bulletDamage;
                test.transform.parent = null;
                test.gameObject.GetComponent<Rigidbody>().AddForce(bulletDir * Time.deltaTime * 80000);
                Debug.DrawLine(pos, pos + bulletDir * 10, Color.red, Mathf.Infinity);
                
       //         if(myWeaponID == 0)
			    //{
       //             control.rifleAmmo--;
			    //}
       //         else if (myWeaponID == 1)
			    //{
       //             control.pistolAmmo--;
       //         }
                //Set up other weapons..
            }
    }

    // Get our ammo from gun controller
  //  void OnEnable()
  //  {
  //      control = GameObject.FindObjectOfType<GunController>();

  //      //Rifle
  //      if (myWeaponID == 0)
		//{
  //          int ammo = FindObjectOfType<GunController>().rifleAmmo;
  //          bulletAmmo = ammo;
  //      }
  //      //Pistol
  //      else if (myWeaponID == 1)
		//{
  //          int ammo = FindObjectOfType<GunController>().pistolAmmo;
  //          bulletAmmo = ammo;
  //      }
  //      //Set-up other weapons..
  //  }

    IEnumerator Bulletcooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }

    // draws attack area on the scene
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
