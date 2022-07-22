using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolGun : MonoBehaviour
{
    [SerializeField]
    Bullet bullet;

    [SerializeField]
    float cooldown;

    [SerializeField]
    float bulletDamage;

    public int bulletAmmo;

    bool canShoot = true;

    private int firedRounds;

    public void Fire()
    {
        if (bulletAmmo >= 1)
            if (canShoot)
            {
                canShoot = false;
                bulletAmmo--;
                StartCoroutine(Bulletcooldown());
                Bullet test = Instantiate(bullet, this.transform.position, Quaternion.Euler(this.transform.rotation.x, 0, 0));
                test.damage = bulletDamage;
                test.transform.parent = null;
                test.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * Time.deltaTime * 20000);
                firedRounds++;
            }
    }

    // Start is called before the first frame update
    private void OnEnable()
    {
        int ammo = FindObjectOfType<GunController>().pistolAmmo;
        bulletAmmo = ammo;
    }

	private void OnDisable()
	{
        //make sure we store our spent rounds in gun control
        //GameObject.FindObjectOfType<GunController>().pistolAmmo -= firedRounds;
        //firedRounds = 0;
	}


	// Update is called once per frame
	void Update()
    {

    }
    IEnumerator Bulletcooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
}