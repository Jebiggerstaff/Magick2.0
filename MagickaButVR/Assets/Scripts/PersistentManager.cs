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
    public AudioClip TaskCompleteSound;
    public GameObject UI;

	#region Task Flags & Check Boxes
	//Village Set
	[Header("Village Tasks")]
	public bool firstSpell = false;
	public bool SamMurdered = false;
	public bool repairBridge = false;
	public GameObject SamMurderedCB;
	public GameObject firstSpellCB;
	public GameObject repairBridgeCB;
	//Forest Set
	[Header("Forest Tasks")]
	public bool enteredForest = false;
	public bool surviveAmbush = false;
	public bool killedAllGoblins = false;
	public int totalGoblins;
	public int killedGoblins;
	public bool escapeForest = false;
	public bool burnVines = false;
	public GameObject enteredForestCB;
	public GameObject surviveAmbushCB;
	public GameObject killedAllGoblinsCB;
	public GameObject escapeForestCB;
	public GameObject burnVinesCB;
	//Castle Set
	[Header("Castle Tasks")]
	public bool enteredCastle = false;
	public bool gateOpened = false;
	public bool RecoverCure = false;
	public GameObject enteredCastleCB;
	public GameObject gateOpenedCB;
	public GameObject RecoverCureCB;
	//Cave Set
	[Header("Cave Tasks")]
	public bool enteredCave = false;
	public bool killedAllWolves = false;
	public int totalWolves;
	public int killedWolves;
	public bool openPortcullis = false;
	public GameObject enteredCaveCB;
	public GameObject killAllWolvesCB;
	public GameObject openPortcullisCB;
	//Misc Set
	[Header("Misc Tasks")]
	public bool fullyExplored = false;
	public GameObject fullyExploredCB;
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
				enteredForestCB.SetActive(true);
				TaskComplete(true, "Forest discovered");
			}
			else if (!enteredCastle && zone == "Castle")
			{
				enteredCastle = true;
				enteredCastleCB.SetActive(true);
				TaskComplete(true, "Castle discovered");
			}
			else if (!enteredCave && zone == "Cave")
			{
				enteredCave = true;
				enteredCaveCB.SetActive(true);
				TaskComplete(true, "Cave discovered");
			}

			if (enteredForest && enteredCastle && enteredCave)
			{
				fullyExplored = true;
				fullyExploredCB.SetActive(true);
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
        if (active == true)
        {
            UI.GetComponent<AudioSource>().clip = TaskCompleteSound;
            UI.GetComponent<AudioSource>().Play();
        }
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
		escapeForest = false;
		burnVines = false;
		surviveAmbush = false;
	}

	public void GoblinKilled(bool b)
	{
		killedGoblins++;
		if (!SamMurdered)
		{
			SamMurdered = true;
			SamMurderedCB.SetActive(true);
			TaskComplete(true, "Murdered the lonely goblin that only wanted a friend.");
		}
		if (killedGoblins == totalGoblins)
		{
			killedAllGoblins = true;
			killedAllGoblinsCB.SetActive(true);
			TaskComplete(true, "Defeated the goblin threat.");
		}
	}

	public void WolfKilled(bool b)
	{
		killedWolves++;
		if(killedWolves == totalWolves)
		{
			
		}
	}

	#region set variables
	public void SetZone(string z) { zone = z; Debug.Log(zone); }
	public void SetPlayer(GameObject p) { player = p; }
	public void SetFirstSpell(bool b) { firstSpell = b; }
	#endregion
	#region get variables
	public string GetZone() { return zone; }
	public bool GetFirstSpell() { return firstSpell; }
	#endregion
}