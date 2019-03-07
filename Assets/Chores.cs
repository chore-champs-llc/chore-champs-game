using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chores : MonoBehaviour
{

	public Text ChoreDisplay;
	public Text title;
	
	[Tooltip("Chores to be done by visitors")]
    public string[] ChoresList;
	
	[Tooltip("Max time before the program resets (In seconds)")]
	public float maxTime;

	private float timer;

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
	}

	//Generates a random chore for someone to do in order to win a raffle.
	public void GenerateChore()
	{
		timer = 0;
		int myElement = Random.Range(0, ChoresList.Length);

		ChoreDisplay.text = "Your Chore Is To <b>" + ChoresList[myElement] + "</b>!";
	}
}
