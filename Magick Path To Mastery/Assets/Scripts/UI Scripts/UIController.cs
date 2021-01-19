using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using System;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;


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

    public int spellsknown=0;

    public GameObject[] SpellSlots;

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
    bool knowsRain = false;
    bool knowsPolymorph = false;
    bool knowsWaterWalking = false;
    bool knowsConjureCrate = false;
    bool knowsConjureBoulder = false;
    bool knowsTeleportTown = false;
    bool knowsTeleportForest = false;
    bool knowsTeleportCastle = false;
    bool knowsTeleportCave = false;
    bool knowsFlipWorld = false;
    #endregion

    bool InOptionsMenu = false;
    bool InSpellbookMenu = false;
    public bool VRmode;

    public AudioClip PageTurn;
    public AudioClip BookOpen;

    private PlayerInputActions controls;

    private void Awake()
    {
        controls = new PlayerInputActions();
        controls.Enable();
    }

    void Start()
    {
            SwitchToNormal();

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

        if (VRmode == true)
        {
            MainMenuGroup.SetActive(false);
            SwitchToVR();
        }
        
        //SpellSlots = GameObject.FindGameObjectsWithTag("SpellSlot");
        SpellbookUI.SetActive(false);
    }
     
    private void Update()
    {
        //open pause menu
        if (controls.UI.PauseButton.triggered && InOptionsMenu == false)
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
        else if (controls.UI.PauseButton.triggered && InOptionsMenu == true)
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
        if (controls.UI.SpellBookButton.triggered && InSpellbookMenu == false)
        {
            InSpellbookMenu = true;
            firstPersonGroup.GetComponent<FirstPersonAIO>().playerCanMove = false;
            firstPersonGroup.GetComponent<FirstPersonAIO>().enableCameraMovement = false;
            Cursor.lockState = CursorLockMode.None;
            HUD.SetActive(false);
            Cursor.visible = true;
            SpellbookUI.SetActive(true);
            spellDisplay.GetComponent<SpellDisplay>().Clear();
            OpenBook();
        }
        //close Spellbook
        else if(controls.UI.SpellBookButton.triggered && InSpellbookMenu == true)
        {
            InSpellbookMenu = false;
            firstPersonGroup.GetComponent<FirstPersonAIO>().playerCanMove = true;
            firstPersonGroup.GetComponent<FirstPersonAIO>().enableCameraMovement = true;
            Cursor.lockState = CursorLockMode.Locked;
            HUD.SetActive(true);
            Cursor.visible = false;
            SpellbookUI.SetActive(false);
            OpenBook();
        }

    }

    void MainToGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        MainMenuGroup.SetActive(false);
        firstPersonGroup.SetActive(true);
		PersistentManager.instance.player = firstPersonGroup;
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
        SceneManager.LoadScene(2);
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
        TurnPage();
    }

    void SpellsToCodex()
    {
        SpellsPage.SetActive(false);
        CodexPage.SetActive(true);
        TurnPage();
    }

    void TasksToSpells()
    {
        TasksPage.SetActive(false);
        SpellsPage.SetActive(true);
        TurnPage();
    }

    void CodexToSpells()
    {
        CodexPage.SetActive(false);
        SpellsPage.SetActive(true);
        TurnPage();
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
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Tar Pool Q-R-E";
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
            case "qrf":
                if (knowsLight == false)
                {
                    knowsLight = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Light Q-R-F";
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
            #region Rain
            case "qfe":
                if (knowsRain == false)
                {
                    knowsRain = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Rain Q-F-E";
                    spellsknown++;
                }

                break;
            #endregion
            #region Polymorph
            case "ref":
                if (knowsPolymorph == false)
                {
                    knowsPolymorph = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Polymorph R-E-F";
                    spellsknown++;
                }

                break;
            #endregion
            #region Water Walking
            case "rqf":
                if (knowsWaterWalking == false)
                {
                    knowsWaterWalking = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Water Walking R-Q-F";
                    spellsknown++;
                }

                break;
            #endregion
            #region Conjure Crate
            case "ffq":
                if (knowsConjureCrate == false)
                {
                    knowsConjureCrate = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Conjure: Crate F-F-Q";
                    spellsknown++;
                }

                break;
            #endregion
            #region Conjure Boulder
            case "ffe":
                if (knowsConjureBoulder == false)
                {
                    knowsConjureBoulder = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Conjure: Boulder F-F-E";
                    spellsknown++;
                }

                break;
            #endregion
            #region Teleport Town
            case "fqq":
                if (knowsTeleportTown == false)
                {
                    knowsTeleportTown = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Teleport: Town F-Q-Q";
                    spellsknown++;
                }
                break;
            #endregion
            #region Teleport Forest
            case "fqe":
                if (knowsTeleportForest == false)
                {
                    knowsTeleportForest = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Teleport: Forest F-Q-E";
                    spellsknown++;
                }
                break;
            #endregion
            #region Teleport Castle
            case "fqr":
                if (knowsTeleportCastle == false)
                {
                    knowsTeleportCastle = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Teleport: Castle F-Q-R";
                    spellsknown++;
                }
                break;
            #endregion
            #region Teleport Cave
            case "fqf":
                if (knowsTeleportCave == false)
                {
                    knowsTeleportCave = true;
                    SpellSlots[spellsknown].GetComponent<Text>().text = "Teleport: Cave F-Q-F";
                    spellsknown++;
                }
                break;
            #endregion
           
            default:
                break;
        }
    }

    public void TurnPage()
    {
        GetComponent<AudioSource>().clip = PageTurn;
        GetComponent<AudioSource>().Play();
    }
    public void OpenBook()
    {
        GetComponent<AudioSource>().clip = BookOpen;
        GetComponent<AudioSource>().Play();
    }

    IEnumerator SwitchToVR()
    {
        // Device names are lowercase, as returned by `XRSettings.supportedDevices`.
        string desiredDevice = "oculus"; // Or "cardboard".

        // Some VR Devices do not support reloading when already active, see
        // https://docs.unity3d.com/ScriptReference/XR.XRSettings.LoadDeviceByName.html
        if (String.Compare(XRSettings.loadedDeviceName, desiredDevice, true) != 0)
        {
            XRSettings.LoadDeviceByName(desiredDevice);

            // Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
            yield return null;
        }

        // Now it's ok to enable VR mode.
        XRSettings.enabled = true;
    }

    IEnumerator SwitchToNormal()
    {
        // Empty string loads the "None" device.
        XRSettings.LoadDeviceByName("");

        // Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
        yield return null;

        // Restore camera settings.
        ResetCameras();
    }

    // Resets camera transform and settings on all enabled eye cameras.
    void ResetCameras()
    {
        // Camera looping logic copied from GvrEditorEmulator.cs
        for (int i = 0; i < Camera.allCameras.Length; i++)
        {
            Camera cam = Camera.allCameras[i];
            if (cam.enabled && cam.stereoTargetEye != StereoTargetEyeMask.None)
            {
                // Reset local position.
                // Only required if you change the camera's local position while in 2D mode.
                cam.transform.localPosition = Vector3.zero;

                // Reset local rotation.
                // Only required if you change the camera's local rotation while in 2D mode.
                cam.transform.localRotation = Quaternion.identity;

                // No longer needed, see issue github.com/googlevr/gvr-unity-sdk/issues/628.
                // cam.ResetAspect();

                // No need to reset `fieldOfView`, since it's reset automatically.
                
            }
        }
    }
}
