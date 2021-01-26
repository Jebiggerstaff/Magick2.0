using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;


public class SpellDisplay : MonoBehaviour
{
    public GameObject fireball;
    public GameObject light;
    public GameObject Crate;
    public GameObject Boulder;
    public GameObject identifyGlow;
    public GameObject grease;
    public GameObject player;
    public GameObject playerCamera;
    public GameObject spellTarget;
    public GameObject spellGuide;
    public GameObject UI;
    public GameObject HasteScreenEffect;
    public GameObject JumpScreenEffect;
    public GameObject RainCloud;
    private GameObject spawnedRain = null;
    private GameObject spawnedLight = null;
    private GameObject spawnedCrate = null;
    private GameObject spawnedBoulder = null;


    public Text SpellProgressText;
    public float identifyDistance;

    #region UISpellGameobjects

    public GameObject fireballUI;
    public GameObject greaseUI;
    public GameObject jumpUI;
    public GameObject levitationUI;
    public GameObject hasteUI;
    public GameObject telekinesisUI;
    public GameObject lightUI;
    public GameObject identifyUI;
    public GameObject rainUI;
    public GameObject polymorphUI;
    public GameObject waterWalkingUI;
    public GameObject ConjureCrateUI;
    public GameObject ConjureBoulderUI;
    public GameObject TeleportTownUI;
    public GameObject TeleportForestUI;
    public GameObject TeleportCastleUI;
    public GameObject TeleportCaveUI;
    public GameObject FlipWorldUI;

    #endregion

    Transform unchild;
    Text text; //The text object used to display spells on screen
    string activeSpell = null; //Determines if there is a spell effect currently active
    string input = ""; //Current spell input
    string displayText = ""; //Used in conjunction with Text text
    public float ForceMod = 1000f; //Used to move objects in telekinesis
    public float spellLongevity = 5f; //Length of spell effects
    float targetDistance; //Distance between target and object (Telekinesis)
    bool playerTouching; //Determines if player is touching object that is being targeted
    Vector3 move; //Used to move objects in telekinesis
    double spellEffectsTimer = 0; //Used to countdown how long a spell lasts
    Material mat = null;//Used for telekinesis to get material of spellTarget;
    GameObject[] identifytargets;
    Vector3 polyTemp;
    public BoxCollider water;    

    public AudioClip hasteSE;
    public AudioClip JumpSE;
    public AudioClip IdentifySE;

    public GameObject TownTP;
    public GameObject ForestTP;
    public GameObject CastleTP;
    public GameObject CaveTP;

    private PlayerInputActions controls;
    Keyboard keyboard = Keyboard.current;

    void Start()
    {
        text = GetComponent<Text>();
    }
    private void Awake()
    {
        controls = new PlayerInputActions();
        controls.Enable();
    }


    void Update()
    {
        
        //Detects spell inputs
        if (/*!string.IsNullOrEmpty(input) &&*/ activeSpell == null)
        {
            if (displayText.Length == 3)
                input = "";
            else if (controls.Player._1stSpellKey.triggered)
                input = "q";
            else if (controls.Player._2ndSpellKey.triggered)
                input = "e";
            else if (controls.Player._3rdSpellKey.triggered)
                input = "r";
            else if (controls.Player._4thSpellKey.triggered)
                input = "f";

            if (input == "q" || input == "e" || input == "r" || input == "f")
            {

                //ensures spells only go to 3 commands
                if (displayText.Length < 3)
                {
                    Debug.Log(input);
                    //Display rune
                    switch (input)
                    {
                        case "q":
                            if (displayText.Length == 0)
                                SpellProgressText.text += "Evocation";
                            else if (displayText.Length == 1)
                                SpellProgressText.text += " -- Self";
                            else if (displayText.Length == 2)
                                SpellProgressText.text += " -- Gravity";
                            break;
                        case "e":
                            if (displayText.Length == 0)
                                SpellProgressText.text += "Enchantment";
                            else if (displayText.Length == 1)
                                SpellProgressText.text += " -- Stranger";
                            else if (displayText.Length == 2)
                                SpellProgressText.text += " -- Primal";
                            break;
                        case "r":
                            if (displayText.Length == 0)
                                SpellProgressText.text += "Transmutation";
                            else if (displayText.Length == 1)
                                SpellProgressText.text += " -- Area";
                            else if (displayText.Length == 2)
                                SpellProgressText.text += " -- Mental";
                            break;
                        case "f":
                            if (displayText.Length == 0)
                                SpellProgressText.text += "Illusion";
                            else if (displayText.Length == 1)
                                SpellProgressText.text += " -- World";
                            else if (displayText.Length == 2)
                                SpellProgressText.text += " -- Ascendant";
                            break;
                        default:
                            break;
                    }
                    displayText += input;
                    input = "";
                }
            }
        
        }
        

        //Detects if spell timer is up or the user is ending a spell

        if ((spellEffectsTimer <= 0 || controls.Player.CancelSpell.triggered) && activeSpell != null)
        {
            Clear();
            activeSpell = null;
            spellEffectsTimer = 0;
        }

        //Detects if user is clearing their spell
        
        else if (controls.Player.CancelSpell.triggered)
        {
            Clear();
            DestroyRunes();
        }

        //Counts down spell timer
        else if (spellEffectsTimer > 0)
        {
            //finds if the object has been destroyed
            if (spellTarget == null)
            {
                activeSpell = null;
            }

            spellEffectsTimer -= Time.deltaTime;
        }

        //Activates spell effects
        if (spellEffectsTimer > 0 && activeSpell != null)
        {
            switch (activeSpell)
            {
                #region TELEKINESIS
                case "TELEKINESIS":
                    targetDistance = Vector3.Distance(spellGuide.transform.position, spellTarget.transform.position);
                    ForceMod = 2000;
                    ForceMod = ForceMod * targetDistance;
                    if (targetDistance >= .2 && playerTouching == false)
                    {
                        spellTarget.GetComponent<Rigidbody>().velocity = spellTarget.GetComponent<Rigidbody>().velocity / 4f;
                        spellTarget.GetComponent<Rigidbody>().AddForce((spellGuide.transform.position - spellTarget.transform.position).normalized * (ForceMod) * Time.smoothDeltaTime, mode: ForceMode.Impulse);
                    }
                    else if (playerTouching == true)
                    {
                        spellTarget.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    }
                    else if (targetDistance <= .15 && spellTarget.GetComponent<Rigidbody>().velocity.x <= .2f && spellTarget.GetComponent<Rigidbody>().velocity.y <= .2f && spellTarget.GetComponent<Rigidbody>().velocity.z <= .2f)
                    {
                        spellTarget.GetComponent<Rigidbody>().velocity += new Vector3(Random.Range(-.05f, .05f), Random.Range(-.05f, .05f), Random.Range(-.05f, .05f));
                    }
                    break;
                #endregion
                default:
                    break;
            }
        }

        //Probably move this to when the spell activates, then deactivate it when a spell ends
        //Otherwise have it under where spell effects take place
        //Detects if haste is active and then modifies FOV
        if (player.GetComponent<FirstPersonAIO>().walkSpeed != 4)
        {
            if (controls.Player.CancelSpell.triggered)
            {
                playerCamera.GetComponent<Camera>().fieldOfView = 60;
                player.GetComponent<FirstPersonAIO>().walkSpeed = 4;
                HasteScreenEffect.SetActive(false);
            }
        }
        if (player.GetComponent<FirstPersonAIO>().jumpPower != 5)
        {

            if (controls.Player.Jump.triggered)
            {
                player.GetComponent<AudioSource>().Play();
            }

            if (controls.Player.CancelSpell.triggered)
            {
                player.GetComponent<FirstPersonAIO>().jumpPower = 5;
                JumpScreenEffect.SetActive(false);
            }
        }

        //Detects mouse wheel scroll, and then applies it to a spell if possible
        if (controls.Player.Scroll.ReadValue<Vector2>() != new Vector2(0, 0))
        {
            switch (activeSpell)
            {
                #region TELEKINESIS
                case "TELEKINESIS":
                    if (Vector3.Distance(spellGuide.transform.position, player.transform.position) <= 10 && Vector3.Distance(spellGuide.transform.position, player.transform.position) >= 3)
                    {
                        //Debug.Log((Vector3.Distance(spellGuide.transform.position, player.transform.position)));
                        move = spellGuide.transform.localPosition;
                        move.z += controls.Player.Scroll.ReadValue<float>() / 10f;
                        spellGuide.transform.localPosition = move;
                    }
                    else if (Vector3.Distance(spellGuide.transform.position, player.transform.position) > 10 && controls.Player.Scroll.ReadValue<float>() <= 0)
                    {
                        //Debug.Log((Vector3.Distance(spellGuide.transform.position, player.transform.position)));
                        move = spellGuide.transform.localPosition;
                        move.z = 9.5f;
                        spellGuide.transform.localPosition = move;
                    }
                    else if (Vector3.Distance(spellGuide.transform.position, player.transform.position) < 3 && controls.Player.Scroll.ReadValue<float>() >= 0)
                    {
                        //Debug.Log((Vector3.Distance(spellGuide.transform.position, player.transform.position)));
                        move = spellGuide.transform.localPosition;
                        move.z = 3.2f;
                        spellGuide.transform.localPosition = move;
                    }
                    break;
                #endregion
                #region POLYMORPH
                case "POLYMORPH":
                    if(spellTarget.transform.lossyScale.magnitude <= polyTemp.magnitude*1.5 && controls.Player.Scroll.ReadValue<float>() >= 0)
                    {                     
                        spellTarget.transform.localScale += new Vector3(.1f,.1f,.1f);           
                    }
                    else if (spellTarget.transform.lossyScale.magnitude >= polyTemp.magnitude * .5 && controls.Player.Scroll.ReadValue<float>() <= 0)
                    {
                        spellTarget.transform.localScale -= new Vector3(.1f, .1f, .1f);
                    }
                    break;
                #endregion
                default:
                    break;
            }
        }

        //Displays spells
        if (displayText.Length == 3 && activeSpell == null)
        {
            switch (displayText)
            {
                #region Fireball
                case "qee":
                    UI.GetComponent<UIController>().AddToSpellbook(displayText);
                    fireballUI.SetActive(true);
                    break;
                #endregion
                #region Grease Pool
                case "qre":
                    UI.GetComponent<UIController>().AddToSpellbook(displayText);
                    greaseUI.SetActive(true);
                    break;
                #endregion
                #region Jump
                case "eqq":
                    UI.GetComponent<UIController>().AddToSpellbook(displayText);
                    if (activeSpell == null)
                    {
                        jumpUI.SetActive(true);
                    }
                    break;
                #endregion
                #region Haste
                case "eqf":
                    UI.GetComponent<UIController>().AddToSpellbook(displayText);
                    if (activeSpell == null)
                    {
                        hasteUI.SetActive(true);
                    }
                    break;
                #endregion
                #region Levitation
                case "eeq":
                    UI.GetComponent<UIController>().AddToSpellbook(displayText);
                    if (activeSpell == null)
                    {
                        levitationUI.SetActive(true);
                    }
                    break;
                #endregion
                #region Telekinesis
                case "req":
                    UI.GetComponent<UIController>().AddToSpellbook(displayText);
                    if (activeSpell == null)
                    {
                        telekinesisUI.SetActive(true);
                    }
                    break;
                #endregion
                #region Light
                case "qrf":
                    UI.GetComponent<UIController>().AddToSpellbook(displayText);
                    if (activeSpell == null)
                    {
                        lightUI.SetActive(true);
                    }
                    break;
                #endregion
                #region Identify
                case "erf":
                    UI.GetComponent<UIController>().AddToSpellbook(displayText);
                    if (activeSpell == null)
                    {
                        identifyUI.SetActive(true);
                    }
                    break;
                #endregion
                #region Rain
                case "qfe":
                    UI.GetComponent<UIController>().AddToSpellbook(displayText);
                    if (activeSpell == null)
                    {
                        rainUI.SetActive(true);
                    }
                    break;
                #endregion
                #region Polymorph
                case "ref":
                    UI.GetComponent<UIController>().AddToSpellbook(displayText);
                    if (activeSpell == null)
                    {
                        polymorphUI.SetActive(true);
                    }
                    break;
                #endregion
                #region Water Walking
                case "rqf":
                    UI.GetComponent<UIController>().AddToSpellbook(displayText);
                    if (activeSpell == null)
                    {
                        waterWalkingUI.SetActive(true);
                    }
                    break;
                #endregion
                #region Conjure Crate
                case "ffq":
                    UI.GetComponent<UIController>().AddToSpellbook(displayText);
                    ConjureCrateUI.SetActive(true);
                    break;
                #endregion
                #region Conjure Boulder
                case "ffe":
                    UI.GetComponent<UIController>().AddToSpellbook(displayText);
                    ConjureBoulderUI.SetActive(true);
                    break;
                #endregion
                #region Teleport Town
                case "fqq":
                    UI.GetComponent<UIController>().AddToSpellbook(displayText);
                    TeleportTownUI.SetActive(true);
                    break;
                #endregion
                #region Teleport Forest
                case "fqe":
                    if (PersistentManager.instance.enteredForest == true)
                    {
                        UI.GetComponent<UIController>().AddToSpellbook(displayText);
                        TeleportForestUI.SetActive(true);
                    }
                    break;
                #endregion
                #region Teleport Castle
                case "fqr":
                    if (PersistentManager.instance.enteredCastle == true)
                    {
                        UI.GetComponent<UIController>().AddToSpellbook(displayText);
                        TeleportCastleUI.SetActive(true);
                    }
                    break;
                #endregion
                #region Teleport Cave
                case "fqf":
                    if (PersistentManager.instance.enteredCave == true)
                    {
                        UI.GetComponent<UIController>().AddToSpellbook(displayText);
                        TeleportCaveUI.SetActive(true);
                    }
                    break;
                #endregion
                default:
                    break;
            }
        }

        //Activates Spells
        if (controls.Player.Fire.triggered && displayText.Length == 3 && activeSpell == null)
        {
			if (!PersistentManager.instance.firstSpell)
				PersistentManager.instance.firstSpell = true;
            switch (displayText)
            {
                #region Fireball
                case "qee":
                    Instantiate(fireball, new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y + .1f, playerCamera.transform.position.z), playerCamera.transform.rotation);
                    fireballUI.SetActive(false);
                    displayText = "";
                    break;
                #endregion
                #region Grease Pool
                case "qre":
                    Instantiate(grease, new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y + .1f, playerCamera.transform.position.z), playerCamera.transform.rotation);
                    greaseUI.SetActive(false);
                    displayText = "";
                    break;
                #endregion
                #region Jump
                case "eqq":
                    if (activeSpell == null)
                    {
                        player.GetComponent<FirstPersonAIO>().jumpPower = 10;
                        spellEffectsTimer = spellLongevity;
                        displayText = "";
                        jumpUI.SetActive(false);
                        activeSpell = "JUMP";
                        JumpScreenEffect.SetActive(true);
                        player.GetComponent<AudioSource>().clip = JumpSE;
                    }
                    break;
                #endregion
                #region Haste
                case "eqf":
                    if (activeSpell == null)
                    {
                        displayText = "";
                        player.GetComponent<FirstPersonAIO>().walkSpeed = 20;
                        spellEffectsTimer = spellLongevity;
                        hasteUI.SetActive(false);
                        activeSpell = "HASTE";
                        playerCamera.GetComponent<Camera>().fieldOfView = 75;
                        HasteScreenEffect.SetActive(true);
                        player.GetComponent<AudioSource>().clip = hasteSE;
                        player.GetComponent<AudioSource>().Play();
                    }

                    break;
                #endregion
                #region Levitation
                case "eeq":
                    if (activeSpell == null)
                    {
                        getTarget();
                        if (spellTarget.GetComponent<Rigidbody>() != null && spellTarget != player)
                        {
                            Debug.Log(spellTarget);
                            spellTarget.GetComponent<Rigidbody>().useGravity = false;
                            spellTarget.GetComponent<Rigidbody>().freezeRotation = true;
                            spellTarget.AddComponent<Levitate>();
                            spellEffectsTimer = spellLongevity * 6;
                            displayText = "";
                            levitationUI.SetActive(false);
                            activeSpell = "LEVITATION";
                        }
                    }
                    break;
                #endregion
                #region Telekinesis
                case "req":
                    if (activeSpell == null)
                    {
                        displayText = "";
                        telekinesisUI.SetActive(false);
                        getTarget();
                        //Determines if object is allowed to be targeted
                        if (spellTarget.GetComponent<Rigidbody>() != null && spellTarget != player)
                        {
                            //Determines if object has the renderer or if its children do, then lights the renderer up
                            if (spellTarget.GetComponent<Renderer>() != null)
                            {
                                mat = spellTarget.GetComponent<Renderer>().material;
                                mat.EnableKeyword("_UseEmissiveIntensity");
                                mat.SetColor("_EmissiveColor", new Color(1, 1, 1, 1) * .2f);
                            }
                            else if (spellTarget.GetComponentsInChildren<Renderer>() != null)
                            {
                                mat = spellTarget.GetComponentInChildren<Renderer>().material;
                                mat.EnableKeyword("_UseEmissiveIntensity");
                                mat.SetColor("_EmissiveColor", new Color(1, 1, 1, 1) * .2f);
                            }
                            else
                            {
                                displayText = "";
                            }
                            //activates effects of telekinesis
                            spellTarget.GetComponent<Rigidbody>().useGravity = false;
                            spellEffectsTimer = spellLongevity * 10;
                            activeSpell = "TELEKINESIS";
                        }
                    }
                    break;
                #endregion
                #region Light
                case "qrf":
                    if (activeSpell == null)
                    {
                        displayText = "";
                        lightUI.SetActive(false);
                        int layerMask = 0 << 8;
                        layerMask = ~layerMask;
                        RaycastHit hit;
                        if (spawnedLight != null)
                        {
                            Destroy(spawnedLight);
                        }                
                        if (Physics.Raycast(new Ray(playerCamera.transform.position, playerCamera.transform.forward), out hit, 9.9f, layerMask))
                        {
                            spawnedLight = Instantiate(light, hit.point, transform.rotation);
                        }
                        else
                             spawnedLight = Instantiate(light, spellGuide.transform.position, transform.rotation);
                    }
                    activeSpell = "LIGHT";
                    break;
                #endregion
                #region Identify
                case "erf":
                    if (activeSpell == null)
                    {
                        identifytargets = GameObject.FindGameObjectsWithTag("Identifiable");
                        foreach(GameObject target in identifytargets)
                        {
                            if (Vector3.Distance(player.transform.position, target.transform.position) < identifyDistance) {
                                if (target.transform.childCount == 0 || target.transform.GetChild(0).name != "IdentifyGlow(Clone)")
                                    Instantiate(identifyGlow, target.transform.position, transform.rotation, target.transform);
                            }                       
                        }
                        player.GetComponent<AudioSource>().clip = IdentifySE;
                        player.GetComponent<AudioSource>().Play();
                    }
                    break;
                #endregion
                #region Rain
                case "qfe":
                    if (activeSpell == null)
                    {
                        displayText = "";
                        rainUI.SetActive(false);
                        if (spawnedRain != null)
                        {
                            Destroy(spawnedRain);
                            spawnedRain = Instantiate(RainCloud, player.transform.position + (Vector3.up * 50), player.transform.rotation);
                        }
                        else
                            spawnedRain = Instantiate(RainCloud, player.transform.position + (Vector3.up * 50), player.transform.rotation);
                    }
                    activeSpell = "RAIN";
                    break;
                #endregion
                #region Polymorph
                case "ref":
                    displayText = "";
                    polymorphUI.SetActive(false);
                    getTarget();

                    polyTemp = spellTarget.transform.lossyScale;

                    if (spellTarget.GetComponent<Rigidbody>() != null && spellTarget != player)
                    {
                        spellEffectsTimer = spellLongevity * 10;
                        activeSpell = "POLYMORPH";

                    }
                    else
                    {
                        displayText = "";
                        activeSpell = "";
                    }
                    break;
                #endregion
                #region Water Walking
                case "rqf":
                    displayText = "";
                    waterWalkingUI.SetActive(false);
                    water.enabled = true;              
                    break;
                #endregion
                #region Conjure Crate
                case "ffq":
                    if (activeSpell == null)
                    {
                        displayText = "";
                        ConjureCrateUI.SetActive(false);
                        int layerMask = 0 << 8;
                        layerMask = ~layerMask;
                        RaycastHit hit;
                        if (spawnedCrate != null)
                        {
                            Destroy(spawnedCrate);
                        }
                        if (Physics.Raycast(new Ray(playerCamera.transform.position, playerCamera.transform.forward), out hit, 9.9f, layerMask))
                        {
                            spawnedCrate= Instantiate(Crate, hit.point, transform.rotation);
                        }
                        else
                            spawnedCrate = Instantiate(Crate, spellGuide.transform.position, transform.rotation);
                    }
                    activeSpell = "CONJURECRATE";
                    break;
                #endregion
                #region Conjure Boulder
                case "ffe":
                    if (activeSpell == null)
                    {
                        displayText = "";
                        ConjureBoulderUI.SetActive(false);
                        int layerMask = 0 << 8;
                        layerMask = ~layerMask;
                        RaycastHit hit;
                        if (spawnedBoulder != null)
                        {
                            Destroy(spawnedBoulder);
                        }
                        if (Physics.Raycast(new Ray(playerCamera.transform.position, playerCamera.transform.forward), out hit, 9.9f, layerMask))
                        {
                            spawnedBoulder = Instantiate(Boulder, hit.point, transform.rotation);
                        }
                        else
                            spawnedBoulder = Instantiate(Boulder, spellGuide.transform.position, transform.rotation);
                    }

                    break;
                #endregion
                #region Teleport Town
                case "fqq":
                    if (activeSpell == null)
                    {
                        displayText = "";
                        TeleportTownUI.SetActive(false);
                        player.transform.position = TownTP.transform.position;
                    }
                    break;
                #endregion
                #region Teleport Forest
                case "fqe":
                    if (activeSpell == null)
                    {
                        displayText = "";
                        TeleportForestUI.SetActive(false);

                        if (PersistentManager.instance.enteredForest==true)
                            player.transform.position = ForestTP.transform.position;
                    }
                    break;
                #endregion
                #region Teleport Castle
                case "fqr":
                    if (activeSpell == null)
                    {
                        displayText = "";
                        TeleportCastleUI.SetActive(false);
                        if (PersistentManager.instance.enteredCastle == true)
                            player.transform.position = CastleTP.transform.position;
                    }
                    break;
                #endregion
                #region Teleport Cave
                case "fqf":
                    if (activeSpell == null)
                    {
                        displayText = "";
                        TeleportCaveUI.SetActive(false);
                        if (PersistentManager.instance.enteredCave == true)
                            player.transform.position = CaveTP.transform.position;
                    }
                    break;
                #endregion
                default:
                    displayText = "";
                    break;
            }
			DestroyRunes();
		}
    }

    //Uses raycasts to find what a spell is targeting
    void getTarget()
    {
        RaycastHit hit;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        int layerMask = 0 << 8;
        layerMask = ~layerMask;

        if (Physics.Raycast(ray, out hit, 50, layerMask))
        {
            if (hit.collider != null && hit.collider.gameObject.tag != "Enemy" && hit.collider.gameObject.layer != 2)
            {
                spellTarget = hit.transform.gameObject;
                unchild = spellTarget.transform.parent;
            }
        }
        else
            Debug.Log("Already have a target");

        //Debug code
        //Debug.DrawRay(ray.origin, ray.direction, Color.red, 5f);
        if (spellTarget != null && spellTarget.GetComponent<Rigidbody>() != null)
            Debug.Log("Target: " + spellTarget.name);
        else if (spellTarget != null)
            Debug.Log(spellTarget.name + " cannot be targeted");
        else
            Debug.Log("No Target | " + ray.GetPoint(10f) + " | " + playerCamera.transform.position);
    }

    //Determines if spellTarget of telekinesis would hit the player (Uses collision events from the playerobject)
    public void telekinesisCollide(Collider other, bool touch)
    {
        Debug.Log(other);
        Debug.Log(touch);

        if (other = spellTarget.GetComponent<Collider>())
        {
            if (touch == true)
            {
                Debug.Log("Touching: " + other);
                playerTouching = true;
            }
            else if (touch == false)
            {
                Debug.Log("Stopped touching: " + other);
                playerTouching = false;
            }
        }
    }

    public void DestroyRunes()
    {
        SpellProgressText.text = "";
    }

    public void Clear()
    {

        switch (activeSpell)
        {
            case "TELEKINESIS":
                mat.SetColor("_EmissiveColor", new Color(0, 0, 0, 0));
                mat.DisableKeyword("_UseEmissiveIntensity");
                spellTarget.GetComponent<Rigidbody>().useGravity = true;
                //spellTarget.transform.parent = unchild;
                break;
            case "LEVITATION":
                Destroy(spellTarget.GetComponent<Levitate>());
                spellTarget.GetComponent<Rigidbody>().useGravity = true;
                spellTarget.GetComponent<Rigidbody>().freezeRotation = false;
                break;
            case "HASTE":
                playerCamera.GetComponent<Camera>().fieldOfView = 60;
                player.GetComponent<FirstPersonAIO>().walkSpeed = 4;
                HasteScreenEffect.SetActive(false);
                break;
            default:
                displayText = "";
                break;
        }

        fireballUI.SetActive(false);
        greaseUI.SetActive(false);
        jumpUI.SetActive(false);
        levitationUI.SetActive(false);
        hasteUI.SetActive(false);
        telekinesisUI.SetActive(false);
        lightUI.SetActive(false);
        identifyUI.SetActive(false);
        rainUI.SetActive(false);
        polymorphUI.SetActive(false);
        waterWalkingUI.SetActive(false);
        ConjureBoulderUI.SetActive(false);
        ConjureCrateUI.SetActive(false);
        TeleportCaveUI.SetActive(false);
        TeleportTownUI.SetActive(false);
        TeleportForestUI.SetActive(false);
        TeleportCastleUI.SetActive(false);

        water.enabled = false;

        displayText = "";
        spellTarget = player;
        activeSpell = null;
    }
}

