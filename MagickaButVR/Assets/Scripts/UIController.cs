using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using System;

public class UIController : MonoBehaviour
{
    #region Gameobjects
    public GameObject firstPersonGroup;
    public GameObject VRGroup;
    public GameObject MainMenuGroup;
    public GameObject MainMenu;
    public GameObject MainMenuOptions;
    public GameObject PauseMenu;
    public GameObject spellDisplay;
    public GameObject HUD;
    public GameObject SpellbookUI;
    public GameObject SpellsPage;
    public GameObject CodexPage;
    public GameObject TasksPage;
    #endregion

    private GameObject[] SpellSlots;

    int spellsknown=0;

    #region Buttons
    public Button MainToGameButton;
    public Button MainToOptionsButton;
    public Button MainToDesktopButton;
    public Button OptionsToMainButton;
    public Button PauseToGameButton;
    public Button PauseToOptionsButton;
    public Button PauseToCreditsButton;
    public Button PauseToMainButton;

    public Button SpellsToTasksButton;
    public Button SpellsToCodexButton;
    public Button CodexToSpellsButton;
    public Button TasksToSpellsButton;


    #endregion

    #region KnowsSpells
    bool knowsFireball = false;
    bool knowsGreaseBall = false;
    bool knowsJump = false;
    bool knowsHaste = false;
    bool knowsLevitation = false;
    bool knowsTelekinesis = false;
    bool knowsLight = false;
    bool knowsIdentify = false;
    #endregion

    bool InOptionsMenu = false;
    bool InSpellbookMenu = false;
    public bool VRmode;

    


    void Start()
    {

        XRSettings.enabled = false;

        MainToGameButton.onClick.AddListener(MainToGame);
        MainToOptionsButton.onClick.AddListener(MainToOptions);
        MainToDesktopButton.onClick.AddListener(ToDesktop);
        OptionsToMainButton.onClick.AddListener(OptionsToMain);
        PauseToGameButton.onClick.AddListener(PauseToGame);
        PauseToOptionsButton.onClick.AddListener(PauseToOptions);
        PauseToCreditsButton.onClick.AddListener(PauseToCredits);
        PauseToMainButton.onClick.AddListener(PauseToMain);
        SpellsToTasksButton.onClick.AddListener(SpellsToTasks);
        SpellsToCodexButton.onClick.AddListener(SpellsToCodex);
        TasksToSpellsButton.onClick.AddListener(TasksToSpells);
        CodexToSpellsButton.onClick.AddListener(CodexToSpells);

        SpellSlots = GameObject.FindGameObjectsWithTag("SpellSlot");
        SpellbookUI.SetActive(false);


        if (VRmode == true)
        {
            MainMenuGroup.SetActive(false);
            VRGroup.SetActive(true);
            XRSettings.enabled = true;
        }

    }
     
    private void Update()
    {
        //open pause menu
        if (Input.GetKeyDown(KeyCode.Escape) && InOptionsMenu == false)
        {
            InOptionsMenu = true;
            firstPersonGroup.GetComponent<FirstPersonAIO>().playerCanMove = false;
            firstPersonGroup.GetComponent<FirstPersonAIO>().enableCameraMovement = false;
            Cursor.lockState = CursorLockMode.None;
            HUD.SetActive(false);
            Cursor.visible = true;
            PauseMenu.SetActive(true);
            spellDisplay.GetComponent<SpellDisplay>().Clear();
        }
        //close pause menu
        else if (Input.GetKeyDown(KeyCode.Escape) && InOptionsMenu == true)
        {
            InOptionsMenu = false;
            firstPersonGroup.GetComponent<FirstPersonAIO>().playerCanMove = true;
            firstPersonGroup.GetComponent<FirstPersonAIO>().enableCameraMovement = true;
            Cursor.lockState = CursorLockMode.Locked;
            HUD.SetActive(true);
            Cursor.visible = false;
            PauseMenu.SetActive(false);
        }
        //open Spellbook
        if (Input.GetKeyDown(KeyCode.Tab) && InSpellbookMenu == false)
        {
            InSpellbookMenu = true;
            firstPersonGroup.GetComponent<FirstPersonAIO>().playerCanMove = false;
            firstPersonGroup.GetComponent<FirstPersonAIO>().enableCameraMovement = false;
            Cursor.lockState = CursorLockMode.None;
            HUD.SetActive(false);
            Cursor.visible = true;
            SpellbookUI.SetActive(true);
            spellDisplay.GetComponent<SpellDisplay>().Clear();
        }
        //close Spellbook
        else if(Input.GetKeyDown(KeyCode.Tab) && InSpellbookMenu == true)
        {
            InSpellbookMenu = false;
            firstPersonGroup.GetComponent<FirstPersonAIO>().playerCanMove = true;
            firstPersonGroup.GetComponent<FirstPersonAIO>().enableCameraMovement = true;
            Cursor.lockState = CursorLockMode.Locked;
            HUD.SetActive(true);
            Cursor.visible = false;
            SpellbookUI.SetActive(false);
        }

    }

    void MainToGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        MainMenuGroup.SetActive(false);
        firstPersonGroup.SetActive(true);
		PersistentManager.instance.SetPlayer(firstPersonGroup);
        HUD.SetActive(true);
    }

    void MainToOptions()
    {
        MainMenu.SetActive(false);
        MainMenuOptions.SetActive(true);
    }

    void OptionsToMain()
    {
        MainMenuOptions.SetActive(false);
        MainMenu.SetActive(true);
    }

    void PauseToGame()
    {
        InOptionsMenu = false;
        firstPersonGroup.GetComponent<FirstPersonAIO>().playerCanMove = true;
        firstPersonGroup.GetComponent<FirstPersonAIO>().enableCameraMovement = true;
        Cursor.lockState = CursorLockMode.Locked;
        HUD.SetActive(true);
        Cursor.visible = false;
        PauseMenu.SetActive(false);
    }

    void PauseToOptions()
    {
        Debug.Log("open Options");
    }

    void PauseToCredits()
    {
        Debug.Log("open Credits");
    }

    void PauseToMain()
    {
        PauseMenu.SetActive(false);
		PersistentManager.instance.ResetTasks();
        SceneManager.LoadScene("New Scene");
    }

    void ToDesktop()
    {
        Application.Quit();
        //Debug.Log("Close Game");
    }

    void SpellsToTasks()
    {
        SpellsPage.SetActive(false);
        TasksPage.SetActive(true);
    }

    void SpellsToCodex()
    {
        SpellsPage.SetActive(false);
        CodexPage.SetActive(true);
    }

    void TasksToSpells()
    {
        TasksPage.SetActive(false);
        SpellsPage.SetActive(true);
    }

    void CodexToSpells()
    {
        CodexPage.SetActive(false);
        SpellsPage.SetActive(true);
    }

    public void AddToSpellbook(string spellname)
    {
        

        switch (spellname)
        {
            #region Fireball
            case "qee":
                if (knowsFireball == false)
                {
                    knowsFireball = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Fireball Q-E-E";
                    spellsknown++;
                }

                break;
            #endregion
            #region GreasePool
            case "qre":
                if (knowsGreaseBall == false)
                {
                    knowsGreaseBall = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "GreaseBall Q-R-E";
                    spellsknown++;
                }
                break;
            #endregion
            #region Jump
            case "eqq":
                if (knowsJump == false)
                {
                    knowsJump = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Jump E-Q-Q";
                    spellsknown++;
                }

                break;
            #endregion
            #region Haste
            case "eqf":
                if (knowsHaste == false)
                {
                    knowsHaste = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Haste E-Q-F";
                    spellsknown++;
                }

                break;
            #endregion
            #region Levitation
            case "eeq":
                if (knowsLevitation == false)
                {
                    knowsLevitation = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Levitation E-E-Q";
                    spellsknown++;
                }
                break;
            #endregion
            #region Telekinesis
            case "req":
                if (knowsTelekinesis == false)
                {
                    knowsTelekinesis = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Telekinesis R-E-Q";
                    spellsknown++;
                }

                break;
            #endregion
            #region Light
            case "frf":
                if (knowsLight == false)
                {
                    knowsLight = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Light F-R-F";
                    spellsknown++;
                }

                break;
            #endregion
            #region Identify
            case "erf":
                if (knowsIdentify == false)
                {
                    knowsIdentify = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Identify E-R-F";
                    spellsknown++;
                }

                break;
            #endregion

            default:
                break;
        }
    }

}
