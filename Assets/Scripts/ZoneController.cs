using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZoneController : MonoBehaviour
{
    [System.NonSerialized]
    public int enemiesKilled;

	[SerializeField]
	private Text enemiesKilledText;

	[SerializeField]
	private GameObject winPanel;

	[SerializeField]
	private GameObject pressKeyToContinue;

	private bool hasWon;

	public void Update()
	{
		enemiesKilledText.text = "Enemies Killed: " + enemiesKilled.ToString();

		if(hasWon)
		{
			pressKeyToContinue.SetActive(true);

			if (Input.GetKeyDown("space"))
			{
				DisplayGameOverPanel();
				hasWon = false;
			}
		}
	}

	public void Win()
	{
		hasWon = true;
	}

	public void DisplayGameOverPanel()
	{
		winPanel.SetActive(true);
		pressKeyToContinue.SetActive(false);
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void ResetButtonPressed()
	{
		SceneManager.LoadScene(0);
	}
}
