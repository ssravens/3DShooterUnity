using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField]
    GameObject Weapon1, Weapon2, Weapon3;

    [SerializeField]
    Transform WeaponLocation;

    [System.NonSerialized]
    public GameObject activeWeapon;

    GameObject SpawnedWeapon;

    [System.NonSerialized]
    public int currentGunID = 0;

    [SerializeField]
    private Animator reticuleAnimation;
    [SerializeField]
    private Animator characterAnimation;

    private GunController control;

    [System.NonSerialized]
    public bool canUsePistol;

    [System.NonSerialized]
    public bool canUseRifle;

    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.FindObjectOfType<GunController>();
    }

    // Update is called once per frame
    void Update()
    {
        //RIFLE///
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!canUseRifle)
                return;

            if (SpawnedWeapon != null)
            {
                Destroy(SpawnedWeapon.gameObject);
            }
            currentGunID = 0;
            SpawnedWeapon = Instantiate(Weapon1, WeaponLocation);
            activeWeapon = SpawnedWeapon;
        }
        
        ///PISTOL///
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!canUsePistol)
                return;

            if (SpawnedWeapon != null)
            {
                Destroy(SpawnedWeapon.gameObject);
            }
            currentGunID = 1;
            SpawnedWeapon = Instantiate(Weapon2, WeaponLocation);
            activeWeapon = SpawnedWeapon;
        }

        //ANY "GUN" FIRING
        if (SpawnedWeapon != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                SpawnedWeapon.GetComponent<Gun>().Fire();
                if(!SpawnedWeapon.GetComponent<Gun>().canShoot)
				{
                    reticuleAnimation.Play("Reticule_Shoot");
                    characterAnimation.SetBool("Attack", true);
                }
            }
        }

        //AMMO CONTROL
        if(activeWeapon != null)
		{
            if(activeWeapon.GetComponent<Gun>().myWeaponID == 0)
			{
                activeWeapon.GetComponent<Gun>().bulletAmmo = control.rifleAmmo;
            }
            else if (activeWeapon.GetComponent<Gun>().myWeaponID == 1)
			{
                activeWeapon.GetComponent<Gun>().bulletAmmo = control.pistolAmmo;
			}

        //setup other weapons
		}
    }
}
