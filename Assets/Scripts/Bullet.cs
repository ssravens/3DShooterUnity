using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody RB;

    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

	private void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.tag == "Enemy")
            Destroy(gameObject);
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Enemy")
            Destroy(gameObject);
	}
}
