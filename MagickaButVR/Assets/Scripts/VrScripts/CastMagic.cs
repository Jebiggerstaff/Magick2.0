using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastMagic : MonoBehaviour
{
    public DisplayMagicUI DisplayMagicUI;
    public OVRPlayerController pc;
    private Transform unchild;
    private Material mat = null;
    private RaycastHit hit;

    private Vector3 move; 

    private GameObject Spell;
    private GameObject spawnedLight;

    public GameObject FireballGameObject;
    public GameObject GreasePoolGameObject;
    public GameObject LightGameObject;
    public GameObject Righthand;
    public GameObject spellTarget;
    public GameObject player;
    public GameObject spellGuide;

    public GameObject HasteScreenEffect;
    public GameObject JumpScreenEffect;
    public AudioClip IdentifySE;
    public GameObject identifyGlow;
    public float identifyDistance;
    GameObject[] identifytargets;
    public GameObject RainCloud;
    private GameObject spawnedRain = null;
    public BoxCollider water;
    public GameObject Crate;
    public GameObject Boulder;
    private GameObject spawnedCrate = null;
    private GameObject spawnedBoulder = null;
    Vector3 polyTemp;

    public float spellTimer;
    private float targetDistance;

    #region CastingBooleans
    private bool playerTouching;
    private bool CastingFireball = false;
    private bool CastingTelekinesis = false;
    private bool OngoingTelekinesis = false;
    private bool CastingJump = false;
    private bool OngoingJump = false;
    private bool CastingHaste = false;
    private bool OngoingHaste = false;
    private bool CastingGreasePool = false;
    private bool CastingLight=false;
    private bool CastingIdentify = false;
    private bool CastingRain = false;
    private bool CastingPolymorph = false;
    private bool OngoingPolymorph = false;
    private bool CastingWaterWalking = false;
    private bool CastingConjureCrate = false;
    private bool CastingConjureBoulder = false;
    #endregion

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

    #endregion

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire2"))
        {
            //Activates Spells
            if (CastingFireball)
            {
                Fireball();
                DisplayMagicUI.Channeling = false;
            }//Throws Fireball

            else if(CastingGreasePool)
            {
                GreasePool();
                DisplayMagicUI.Channeling = false;
            }//Throws Grease Pool

            else if (OngoingTelekinesis)
            {
                spellTarget.GetComponent<Rigidbody>().useGravity = true;
                CastingTelekinesis = false;
                OngoingTelekinesis = false;
                spellTarget = null;
                DisplayMagicUI.Channeling = false;
            }//Stops Telekinesis
            else if (CastingTelekinesis)
            {
                Telekinesis();
                OngoingTelekinesis = true;
                
            }//Starts Telekinesis

            else if (CastingJump)
            {
                JumpScreenEffect.SetActive(true);
                jumpUI.SetActive(false);
                spellTimer = 30;
                OngoingJump = true;
                CastingJump = false;
            }//Starts Jump
            else if (spellTimer > 0 && OngoingJump)
            {
                JumpScreenEffect.SetActive(false);
                OngoingJump = false;
                DisplayMagicUI.Channeling = false;
            }//Stops Jump

            else if (CastingHaste)
            {
                HasteScreenEffect.SetActive(true);
                hasteUI.SetActive(false);
                spellTimer = 30;
                OngoingHaste = true;
                CastingHaste = false;
            }//Starts Haste
            else if (spellTimer > 0 && OngoingHaste)
            {
                HasteScreenEffect.SetActive(false);
                OngoingHaste = false;
                DisplayMagicUI.Channeling = false;
                pc.Acceleration = .08f;
            }//Stops Haste

            else if (CastingLight)
            {
                Light();
                DisplayMagicUI.Channeling = false;
            }//Casts Light

            else if (CastingIdentify)
            {
                Identify();
                DisplayMagicUI.Channeling = false;
            }

            else if (CastingRain)
            {
                Rain();
                DisplayMagicUI.Channeling = false;
            }

            else if (CastingConjureCrate)
            {
                ConjureCrate();
                DisplayMagicUI.Channeling = false;
            }

            else if (CastingConjureBoulder)
            {
                ConjureBoulder();
                DisplayMagicUI.Channeling = false;
            }

            else if (CastingWaterWalking)
            {
                WaterWalking();
                DisplayMagicUI.Channeling = false;
            }

            else if (OngoingPolymorph)
            {
                polyTemp = spellTarget.transform.lossyScale;
                CastingPolymorph = false;
                OngoingPolymorph = false;
                spellTarget = null;
                DisplayMagicUI.Channeling = false;
            }

            else if (CastingPolymorph)
            {
                Polymorph();
                OngoingPolymorph = true;
            }

        }//Activates & Deactivates Timed Spells      
        #region JumpTimer
        if (spellTimer > 0 && OngoingJump == true) //starts jump while timer is going and player hasnt canceled it
            pc.JumpForce = .6f;
        else if(spellTimer < 0 && OngoingJump == true)
        {
            JumpScreenEffect.SetActive(false);
            pc.JumpForce = .3f;
            DisplayMagicUI.Channeling = false;
            OngoingJump = false;
        }
        #endregion
        #region HasteTimer
        if (spellTimer > 0 && OngoingHaste == true) //starts jump while timer is going and player hasnt cancelled it
            pc.Acceleration = .3f;
        else if (spellTimer < 0 && OngoingHaste == true)
        {
            HasteScreenEffect.SetActive(false);
            pc.Acceleration = .08f;
            DisplayMagicUI.Channeling = false;
            OngoingHaste = false;
        }
        #endregion

        spellTimer -= Time.deltaTime;

        if (OngoingTelekinesis == true)
        {
            if (spellTarget == null)
            {
                OngoingTelekinesis = false;
                CastingTelekinesis = false;
                DisplayMagicUI.Channeling = false;

            }
            else
            {
                //Debug.LogWarning("Target: " + spellTarget.name);
                targetDistance = Vector3.Distance(spellGuide.transform.position, spellTarget.transform.position);
                float ForceMod = 1000;
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
            }
        }

        if (OngoingPolymorph == true)
        {
            if (spellTarget == null)
            {
                OngoingPolymorph = false;
                CastingPolymorph = false;
                DisplayMagicUI.Channeling = false;

            }
            else
            {
                //Debug.LogError("Primary = " + OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger));

                if (spellTarget.transform.lossyScale.magnitude <= polyTemp.magnitude * 1.5 && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 0)
                {
                    spellTarget.transform.localScale += new Vector3(.1f, .1f, .1f);
                }
                else if (spellTarget.transform.lossyScale.magnitude >= polyTemp.magnitude * .5 && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 0)
                {
                    spellTarget.transform.localScale -= new Vector3(.1f, .1f, .1f);
                }
            }
        }
    }
    

    public void Cast(string[] Combination)//Determines What spell to use
    {
        
        if (Combination[0] == "Evocation" && Combination[1] == "Stranger" && Combination[2] == "Primal")
        {
            if (DisplayMagicUI.RightHand.transform.childCount == 2)
            {
                DisplayMagicUI.Channeling = true;
                fireballUI.SetActive(true);
                Spell = Instantiate(FireballGameObject, DisplayMagicUI.RightHand.transform);
                CastingFireball = true;
            }
            
        }//Fireball

        if (Combination[0] == "Evocation" && Combination[1] == "Area" && Combination[2] == "Primal")
        {
            if (DisplayMagicUI.RightHand.transform.childCount == 2)
            {
                DisplayMagicUI.Channeling = true;
                greaseUI.SetActive(true);
                Spell = Instantiate(GreasePoolGameObject, DisplayMagicUI.RightHand.transform);
                DisplayMagicUI.RightHand.transform.GetChild(1).GetComponent<SphereCollider>().isTrigger = false;
                CastingGreasePool = true;
            }

        }//Grease Pool

        if (Combination[0] == "Transmutation" && Combination[1] == "Stranger" && Combination[2] == "Gravitation")
        {
            DisplayMagicUI.Channeling = true;
            telekinesisUI.SetActive(true);
            CastingTelekinesis = true;
        }//Telekinesis

        if (Combination[0] == "Enchantment" && Combination[1] == "Self" && Combination[2] == "Gravitation")
        {
            DisplayMagicUI.Channeling = true;
            jumpUI.SetActive(true);
            CastingJump = true;
        }//Jump

        if (Combination[0] == "Enchantment" && Combination[1] == "Self" && Combination[2] == "Ascendant")
        {
            DisplayMagicUI.Channeling = true;
            CastingHaste = true;
            hasteUI.SetActive(true);
        }//Haste

        if (Combination[0] == "Evocation" && Combination[1] == "Area" && Combination[2] == "Ascendant")
        {
            DisplayMagicUI.Channeling = true;
            CastingLight = true;
            lightUI.SetActive(true);
        }//Light

        if (Combination[0] == "Enchantment" && Combination[1] == "Area" && Combination[2] == "Ascendant")
        {
            DisplayMagicUI.Channeling = true;
            CastingIdentify = true;
            identifyUI.SetActive(true);
        }//Identify

        if (Combination[0] == "Evocation" && Combination[1] == "World" && Combination[2] == "Primal")
        {
            DisplayMagicUI.Channeling = true;
            CastingRain = true;
            rainUI.SetActive(true);
        }//Rain

        if (Combination[0] == "Transmutation" && Combination[1] == "Stranger" && Combination[2] == "Ascendant")
        {
            DisplayMagicUI.Channeling = true;
            CastingPolymorph = true;
            polymorphUI.SetActive(true);
        }//Polymorph

        if (Combination[0] == "Transmutation" && Combination[1] == "Self" && Combination[2] == "Ascendant")
        {
            DisplayMagicUI.Channeling = true;
            CastingWaterWalking = true;
            waterWalkingUI.SetActive(true);
        }//Water Walking

        if (Combination[0] == "Creation" && Combination[1] == "World" && Combination[2] == "Gravity")
        {
            DisplayMagicUI.Channeling = true;
            CastingConjureCrate = true;
            ConjureCrateUI.SetActive(true);
        }//Conjure Crate

        if (Combination[0] == "Creation" && Combination[1] == "World" && Combination[2] == "Primal")
        {
            DisplayMagicUI.Channeling = true;
            CastingConjureBoulder = true;
            ConjureBoulderUI.SetActive(true);
        }//Conjure Boulder

    }

    public void Polymorph()
    {
        GetTarget();
        if (spellTarget != null)
        {

            polyTemp = spellTarget.transform.lossyScale;

            if (spellTarget.GetComponent<Rigidbody>() != null && spellTarget != player)
            {
                
            }
            else
            {
                OngoingPolymorph = false;
                CastingPolymorph = false;
                DisplayMagicUI.Channeling = false;
            }
        }
        polymorphUI.SetActive(false);
 
    }

    public void ConjureCrate()
    {
        int layerMask = 0 << 8;
        layerMask = ~layerMask;
        RaycastHit hit;
        if (spawnedCrate != null)
        {
            Destroy(spawnedCrate);
        }
        if (Physics.Raycast(new Ray(Righthand.transform.position, Righthand.transform.forward), out hit, 9.9f, layerMask))
        {
            spawnedCrate = Instantiate(Crate, hit.point, transform.rotation);
        }
        else
            spawnedCrate = Instantiate(Crate, spellGuide.transform.position, transform.rotation);

        CastingConjureCrate = false;
        ConjureCrateUI.SetActive(false);
    }
    
    public void ConjureBoulder()
    {
        int layerMask = 0 << 8;
        layerMask = ~layerMask;
        RaycastHit hit;
        if (spawnedBoulder != null)
        {
            Destroy(spawnedBoulder);
        }
        if (Physics.Raycast(new Ray(Righthand.transform.position, Righthand.transform.forward), out hit, 9.9f, layerMask))
        {
            spawnedBoulder = Instantiate(Boulder, hit.point, transform.rotation);
        }
        else
            spawnedBoulder = Instantiate(Boulder, spellGuide.transform.position, transform.rotation);

        CastingConjureBoulder = false;
        ConjureBoulderUI.SetActive(false);
    }

    public void WaterWalking()
    {
        water.enabled = true;
        CastingWaterWalking = false;
        waterWalkingUI.SetActive(false);
    }//Sets water collider to true so the player can walk on it

    public void Rain()
    {
        rainUI.SetActive(false);
        if (spawnedRain != null)
        {
            Destroy(spawnedRain);
            spawnedRain = Instantiate(RainCloud, player.transform.position + (Vector3.up * 50), player.transform.rotation);
        }
        else
            spawnedRain = Instantiate(RainCloud, player.transform.position + (Vector3.up * 50), player.transform.rotation);

        CastingRain = false;
        rainUI.SetActive(false);
    }//Spawns the rain cloud in the air

    public void Identify() 
    {
        identifytargets = GameObject.FindGameObjectsWithTag("Identifiable");
        foreach (GameObject target in identifytargets)
        {
            if (Vector3.Distance(player.transform.position, target.transform.position) < identifyDistance)
            {
                if (target.transform.childCount == 0 || target.transform.GetChild(0).name != "IdentifyGlow(Clone)")
                    Instantiate(identifyGlow, target.transform.position, transform.rotation, target.transform);
            }
        }
        CastingIdentify = false;
        identifyUI.SetActive(false);

    }//Code for putting glow on identifiable objects

    public void Light()
    {
        int layerMask = 0 << 8;
        layerMask = ~layerMask;
        RaycastHit hit;

        if (spawnedLight != null)
        {
            Destroy(spawnedLight);
        }
        if (Physics.Raycast(new Ray(Righthand.transform.position, Righthand.transform.forward), out hit, 9.9f, layerMask))
        {
            spawnedLight = Instantiate(LightGameObject, hit.point, transform.rotation);
        }
        else
            spawnedLight = Instantiate(LightGameObject, spellGuide.transform.position, transform.rotation);  
        
        CastingLight = false;
        lightUI.SetActive(false);

    }//Code for spawning the Light orb

    public void Fireball()
    {
        Spell.transform.parent = null;
        Spell.GetComponent<Rigidbody>().useGravity = true;
        Spell.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        fireballUI.SetActive(false);
        CastingFireball = false;
    }//Code for launching Fireball

    public void GreasePool()
    {
        DisplayMagicUI.RightHand.transform.GetChild(1).GetComponent<SphereCollider>().isTrigger = true;
        Spell.transform.parent = null;
        Spell.GetComponent<Rigidbody>().useGravity = true;
        Spell.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        greaseUI.SetActive(false);
        CastingGreasePool = false;
        
    }

    public void Telekinesis()
    {
        telekinesisUI.SetActive(false);
        GetTarget();
        //Determines if object is allowed to be targeted
        if (spellTarget != null)
        {
            if (spellTarget.GetComponent<Rigidbody>() != null && spellTarget != player)
            {
                //activates effects of telekinesis
                spellTarget.GetComponent<Rigidbody>().useGravity = false;

            }
        }
        else
        {
            OngoingTelekinesis = false;
            CastingTelekinesis = false;
            DisplayMagicUI.Channeling = false;
        }
    } //Code for Activating Telekinesis

    public void GetTarget()
    {
        Ray ray = new Ray(Righthand.transform.position, Righthand.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 30f);

        if (Physics.Raycast(ray, out hit, 50))
        {
            if (hit.collider != null && hit.collider.gameObject.tag != "Enemy" && hit.collider.gameObject.layer != 2)
            {
                spellTarget = hit.transform.gameObject;
                unchild = spellTarget.transform.parent;
            }
        }
        else
            Debug.LogWarning("No Target Hit");
    }//Code for Raycasting to Target
}
