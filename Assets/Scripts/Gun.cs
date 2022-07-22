using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    Bullet bullet;

    [SerializeField]
    float cooldown;

    [SerializeField]
    float bulletDamage;

    public int myWeaponID;

    public int bulletAmmo;

    [System.NonSerialized]
    public bool canShoot = true;

    private GunController control;

	private void Awake()
	{
        control = GameObject.FindObjectOfType<GunController>();
	}

	public void Fire()
    {
        if (bulletAmmo >= 1)
            if (canShoot) 
            {
                canShoot = false;
                bulletAmmo--; 
                StartCoroutine(Bulletcooldown());
                Vector3 pos = Camera.main.transform.position;
                Vector3 bulletDir = (Camera.main.transform.GetChild(0).transform.GetChild(0).transform.position - Camera.main.transform.position).normalized;
                Bullet test = Instantiate(bullet, this.transform.position, Quaternion.identity);
                test.transform.LookAt(Camera.main.transform);
                test.damage = bulletDamage;
                test.transform.parent = null;
                test.gameObject.GetComponent<Rigidbody>().AddForce(bulletDir * Time.deltaTime * 80000);
                Debug.DrawLine(pos, pos + bulletDir * 10, Color.red, Mathf.Infinity);
                
                if(myWeaponID == 0)
			    {
                    control.rifleAmmo--;
			    }
                else if (myWeaponID == 1)
			    {
                    control.pistolAmmo--;
                }
                //Set up other weapons..
            }
    }

    // Get our ammo from gun controller
    void OnEnable()
    {
        control = GameObject.FindObjectOfType<GunController>();

        //Rifle
        if (myWeaponID == 0)
		{
            int ammo = FindObjectOfType<GunController>().rifleAmmo;
            bulletAmmo = ammo;
        }
        //Pistol
        else if (myWeaponID == 1)
		{
            int ammo = FindObjectOfType<GunController>().pistolAmmo;
            bulletAmmo = ammo;
        }
        //Set-up other weapons..
    }

    IEnumerator Bulletcooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
}
