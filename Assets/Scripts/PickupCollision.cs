using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCollision : MonoBehaviour
{
    public int ammoAmount;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "RifleAmmo")
        {
            ammoAmount = other.GetComponent<Ammo>().amount;

            //add the ammo in addition in our gun controller
            GameObject.FindObjectOfType<GunController>().rifleAmmo += ammoAmount;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "PistolAmmo")
        {
            ammoAmount = other.GetComponent<Ammo>().amount;

            //add the ammo in addition in our gun controller
            GameObject.FindObjectOfType<GunController>().pistolAmmo += ammoAmount;
            Destroy(other.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}