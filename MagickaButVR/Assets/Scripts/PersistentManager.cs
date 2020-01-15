using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersistentManager : MonoBehaviour
{
	public static PersistentManager instance {get; private set;}
	public Button resetButton;
	public GameObject player;
	public string zone;
	public GameObject taskComplete;
	public Text taskDesc;
	double timer;

	#region Task Flags & Check Boxes
	public bool enteredForest = false;
	public GameObject entereForestCB;
	public bool enteredCave = false;
	public GameObject enteredCaveCB;
	public bool enteredCastle = false;
	public GameObject enteredCastleCB;
	public bool fullyExplored = false;
	public GameObject fullyExploredCB;
	public bool SamMurdered = false;
	public GameObject SamMurderedCB;
	public bool killedAllGoblins = false;
	public int totalGoblins;
	public int killedGoblins = 0;
	public GameObject killedAllGoblinsCB;
	public bool gateOpened = false;
	public GameObject gateOpenedCB;
	public bool forestEscaped = false;
	public GameObject forestEscapedCB;
	public bool overgrownPathNavigated = false;
	public GameObject overgrownPathNavigatedCB;
	public bool survivedAmbush = false;
	public GameObject survivedAmbushCB;
	#endregion

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
		
		player = GameObject.FindGameObjectWithTag("Player");
		zone = "Village";
	}

	void Update()
	{
		#region Task System
		if (!fullyExplored)
		{
			if (!enteredForest && zone == "Forest")
			{
				enteredForest = true;
				TaskComplete(true, "Forest discovered");
			}
			else if (!enteredCastle && zone == "Castle")
			{
			enteredCastle = true;
				TaskComplete(true, "Castle discovered");
			}
			else if (!enteredCave && zone == "Cave")
			{
				enteredCave = true;
				TaskComplete(true, "Cave discovered");
			}

			if (enteredForest && enteredCastle && enteredCave)
			{
				fullyExplored = true;
				TaskComplete(true, "All locations discovered");
			}
		}
		#endregion

		if (timer > 0)
			timer -= Time.deltaTime;
		else if (timer <= 0)
			TaskComplete(false, "");
	}

	void FixedUpdate()
	{

	}

	public void resetWorld()
	{
		Debug.Log("Resetting World");	
		SceneManager.LoadScene("MainScene");

		if(player == null)
			player = GameObject.FindGameObjectWithTag("Player");
	}

	public void TaskComplete(bool active, string desc)
	{
		taskComplete.SetActive(active);
		taskDesc.text = desc;
		timer = 5;
	}

	public void ResetTasks()
	{
		enteredForest = false;
		enteredCave = false;
		enteredCastle = false;
		fullyExplored = false;
		SamMurdered = false;
		killedAllGoblins = false;
		killedGoblins = 0;
		gateOpened = false;
		forestEscaped = false;
		overgrownPathNavigated = false;
		survivedAmbush = false;
	}

	public void GoblinKilled(bool b)
	{
		killedGoblins++;
		if (!SamMurdered)
		{
			SamMurdered = true;
			//TaskComplete(runInEditMode, "Murdered the lonely goblin that only wanted a friend.");
		}
		if (killedGoblins == totalGoblins)
		{
			killedAllGoblins = true;
			TaskComplete(true, "Defeated the goblin threat.");
		}
	}

	#region set variables
	public void SetZone(string z) { zone = z; Debug.Log(zone); }
	public void SetPlayer(GameObject p) { player = p; }
	#endregion
	#region get variables
	public string GetZone() { return zone; }
	#endregion
}