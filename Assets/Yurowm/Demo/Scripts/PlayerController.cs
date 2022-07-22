using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent (typeof (Animator))]
public class PlayerController : MonoBehaviour {

	public Transform rightGunBone;
	public Transform leftGunBone;
	public Arsenal[] arsenal;

	private Animator animator;

	[SerializeField]
	private Text healthUI;

	[SerializeField]
	private int health = 5;

	void Awake() {
		animator = GetComponent<Animator> ();
		if (arsenal.Length > 0)
			SetArsenal (arsenal[0].name);
		}

	public void SetArsenal(string name) {
		foreach (Arsenal hand in arsenal) {
			if (hand.name == name) {
				if (hand.rightGun != null) {
					GameObject newRightGun = (GameObject) Instantiate(hand.rightGun);
					newRightGun.transform.parent = rightGunBone;
					newRightGun.transform.localPosition = Vector3.zero;
					newRightGun.transform.localRotation = Quaternion.Euler(90, 0, 0);
					}
				if (hand.leftGun != null) {
					GameObject newLeftGun = (GameObject) Instantiate(hand.leftGun);
					newLeftGun.transform.parent = leftGunBone;
					newLeftGun.transform.localPosition = Vector3.zero;
					newLeftGun.transform.localRotation = Quaternion.Euler(90, 0, 0);
				}
				animator.runtimeAnimatorController = hand.controller;
				return;
				}
		}
	}

	[System.Serializable]
	public struct Arsenal {
		public string name;
		public GameObject rightGun;
		public GameObject leftGun;
		public RuntimeAnimatorController controller;
	}

	private void Update()
	{
		if (health <= 0)
		{
			health = 0;
			//Game Over!
			Time.timeScale = 0.1f;
			StartCoroutine(RestartGame());
		}

		healthUI.text = "hp: " + health.ToString();
	}

	IEnumerator RestartGame()
	{
		yield return new WaitForSeconds(.3f);
		SceneManager.LoadScene(0);
		Time.timeScale = 1;
	}

	private void OnTriggerEnter(Collider collision)
	{
		if(collision.gameObject.tag == "Enemy")
			health--;
	}
}
