using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Chores : MonoBehaviour
{

	[Tooltip("Don't Touch")]
	public Text ChoreDisplay;
	[Tooltip("Don't Touch")]
	public Text title;
	
	[Tooltip("Chores to be done by visitors")]
    public string[] ChoresList;
	
	[Tooltip("Max time before the program resets (In seconds)")]
	public float maxTime;

	private float timer;

	private int escapeKeyPress;

	//Information about how many visitors/chores were given during a program run.
	//Chore Champs isn't evil (from what I know, I'm not the CEO), this is just a simple counter so that we can
	//adjust for more people at future events.
	private int VisitorNum;

	//Gets the text that displays when the program first opens.
	private void Start()
	{
		ChoreDisplay.text = "Welcome to <b><color=Red>Chore</color> <color=Blue>Champs</color></b>!";
		title.text = "<b><color=Red>Chore</color> <color=Blue>Champs</color> <color=yellow>Random Chore Game!</color></b>";
	}

	//Timer that displays a welcome text if no one is at the booth for a period of time.
	private void Update()
	{
		timer += Time.deltaTime;

		if (timer >= maxTime)
		{
			ChoreDisplay.text = "Welcome to <b><color=Red>Chore</color> <color=Blue>Champs</color></b>!";
		}

		//Ability to close the program
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			escapeKeyPress++;
			if (escapeKeyPress >= 5)
			{
				Application.Quit();
			}
		}
	}

	//Generates a random chore for someone to do in order to win a raffle.
	public void GenerateChore()
	{
		timer = 0;
		int myElement = Random.Range(0, ChoresList.Length);
		ChoreDisplay.text = "Your Chore Is To <b>" + ChoresList[myElement] + "</b>!";
		
	}
	
	//Increases visitor count when the animation is complete
	private void IncreaseVisitorCount() {
		VisitorNum++;
	}
	
	//Puts final count regardless of how the program is quit.
	private void OnApplicationQuit()
	{
		PlayerPrefsManager.UpdateVisitors(VisitorNum);
		Debug.Log("Final visitor count: " + VisitorNum);
		Debug.Log("Lifetime visitors: " + PlayerPrefsManager.ReturnVisitors());
	}
}