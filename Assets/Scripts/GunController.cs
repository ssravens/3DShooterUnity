using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    [System.NonSerialized]
    public int pistolAmmo;

    [System.NonSerialized]
    public int rifleAmmo;

    [SerializeField]
    private Text ammoText;

    private WeaponSwitcher weaponSwitch;

	private void Awake()
	{
        weaponSwitch = GameObject.FindObjectOfType<WeaponSwitcher>();
	}

	private void Update()
	{
		if(weaponSwitch.activeWeapon != null)
		{
			//rifle
			if (weaponSwitch.currentGunID == 0)
			{
				ammoText.text = "Rifle Ammo: " + rifleAmmo.ToString();
			}
			//pistol
			else if (weaponSwitch.currentGunID == 1)
			{
				ammoText.text = "Pistol Ammo: " + pistolAmmo.ToString();
			}
		}
		//other weapons..
	}

}
