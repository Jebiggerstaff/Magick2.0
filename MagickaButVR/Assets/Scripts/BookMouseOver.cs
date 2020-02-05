using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class BookMouseOver : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{

    public GameObject SpellDesc;
    public GameObject SpellIcon;
    public GameObject SpellTitle;
    public GameObject CodexTitle;
    public GameObject CodexIcon;
    public GameObject CodexData;

    public GameObject VillageTaskList;
    public GameObject ForestTaskList;
    public GameObject CastleTaskList;
    public GameObject MountainTaskList;
    public GameObject MiscTaskList;

    public void OnPointerEnter(PointerEventData eventData)
    {
		# region Spell Page
		if (this.GetComponent<Text>().text == "Fireball Q-E-E")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            SpellTitle.GetComponent<Text>().text = "Fireball";
            SpellDesc.GetComponent<Text>().text = "Sends out a mote of flame, igniting whatever it comes into contact with.";
        }
        if (this.GetComponent<Text>().text == "Tar Pool Q-R-E")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            SpellTitle.GetComponent<Text>().text = "Tar Pool";
            SpellDesc.GetComponent<Text>().text = "Creates a pool of tar, slowing any creatures inside it. It may also be ignited to create a flaming barrier.";
        }
        if (this.GetComponent<Text>().text == "Jump E-Q-Q")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            SpellTitle.GetComponent<Text>().text = "Jump";
            SpellDesc.GetComponent<Text>().text = "Grants the user to leap to great heights.";
        }
        if (this.GetComponent<Text>().text == "Haste E-Q-F")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            SpellTitle.GetComponent<Text>().text = "Haste";
            SpellDesc.GetComponent<Text>().text = "Allows the user to run at super human speeds.";
        }
        if (this.GetComponent<Text>().text == "Levitation E-E-Q")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            SpellTitle.GetComponent<Text>().text = "Levitation";
            SpellDesc.GetComponent<Text>().text = "Suspends an object in the air for a time.";
        }
        if (this.GetComponent<Text>().text == "Telekinesis R-E-Q")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            SpellTitle.GetComponent<Text>().text = "Telekinesis";
            SpellDesc.GetComponent<Text>().text = "Allows the user to lift and manipulate an object.";
        }
        if (this.GetComponent<Text>().text == "Light F-R-F")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            SpellTitle.GetComponent<Text>().text = "Light";
            SpellDesc.GetComponent<Text>().text = "Conjures a sphere of bright light to illuminate an area.";
        }
        if (this.GetComponent<Text>().text == "Identify E-R-F")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            SpellTitle.GetComponent<Text>().text = "Identify";
            SpellDesc.GetComponent<Text>().text = "Reveals objects around the user that can be manipulated by magick.";
        }
        if (this.GetComponent<Text>().text == "Rain Q-F-E")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            SpellTitle.GetComponent<Text>().text = "Rain";
            SpellDesc.GetComponent<Text>().text = "Creates a cloud above, bathing the area in rain.";
        }

        #endregion

        #region Tasks Page
        if (this.GetComponent<Text>().text == "Village Tasks")
        {
            VillageTaskList.SetActive(true);
        }
        if (this.GetComponent<Text>().text == "Forest Tasks")
        {
            ForestTaskList.SetActive(true);
        }
        if (this.GetComponent<Text>().text == "Castle Tasks")
        {
            CastleTaskList.SetActive(true);
        }
        if (this.GetComponent<Text>().text == "Mountain Tasks")
        {
            MountainTaskList.SetActive(true);
        }
        if (this.GetComponent<Text>().text == "Misc. Tasks")
        {
            MiscTaskList.SetActive(true);
        }
        #endregion

        #region Codex Page
        if(this.GetComponent<Text>().text == "Seidrsund")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            CodexTitle.GetComponent<Text>().text = "Seidrsund";
            CodexData.GetComponent<Text>().text = "Seidrsund, Magic’s Sound, is the name of the land in which all things, living and not, reside. The world is filled with underground roots pulsing with a force that the denizens of the world call Magick. The year, according to the official histories is 1351 SG, Since Growth. This refers to the emergence of the first magick trees discovered.";
        }
        if (this.GetComponent<Text>().text == "Seidrwrot")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            CodexTitle.GetComponent<Text>().text = "Seidrwrot";
            CodexData.GetComponent<Text>().text = "Seidrwrot is the name given to the roots which span throughout the world. Most Seidrwrot are deep within the ground, as their power seeps through the world. The strongest of which pierce the crust of the earth and form into trees which feed magical energy into the world directly. These places are locations of great power, and allow the most powerful of wizards to cast grand and sweeping spells.";
        }
        if (this.GetComponent<Text>().text == "Magick")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            CodexTitle.GetComponent<Text>().text = "Magick";
            CodexData.GetComponent<Text>().text = "A mystical force that originates from deep within the earth, and exists in and around all things. It is a force that when harnessed can perform incredible feats. Ancient words from ancestors who could communicate with the very earth itself, when invoked, allow wizards to focus and harness the power of Magick.";
        }
        if (this.GetComponent<Text>().text == "Wizards")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            CodexTitle.GetComponent<Text>().text = "Wizards";
            CodexData.GetComponent<Text>().text = "Wizards, also known as Sorcerers, Magicians, and Casters are those who have trained to harness the magic in the world, and create affects and changes to the world known as Spells. Some are born with old souls, and have a natural aptitude to learning how to wield magick. Their soul on birth was chosen for one reason or another by the spirits of magick that reside in the world.";
        }
        if (this.GetComponent<Text>().text == "The Ancients")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            CodexTitle.GetComponent<Text>().text = "The Ancients";
            CodexData.GetComponent<Text>().text = "The ancestors to all people on the continent, they sailed from far, far away. Their language allowed them to communicate with the trees and the grass, the wind and the clouds, the roots and the land. Their ancient language, though only known in pieces, allows users of magick to communicate enough with all around them to craft spells that are a fraction of the power the ancients held in their mouths.";
        }
        if (this.GetComponent<Text>().text == "Yggrskr")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            CodexTitle.GetComponent<Text>().text = "Yggrskr";
            CodexData.GetComponent<Text>().text = "Your mentor, the reason you are on this quest. He was not born with an affinity for the Arkane as you were, but managed to learn and master its ways through work and study. He has fallen ill, and no regular medicines have been successful in curing him. Your quest has brought you to this place, where a great tree resides in hopes the powerful magick in the area will offer a solution. Perhaps a local mage has crafted some grand potion? ";
        }
        if (this.GetComponent<Text>().text == "Wilfred Hooplesdorf")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            CodexTitle.GetComponent<Text>().text = "Wilfred Hooplesdorf";
            CodexData.GetComponent<Text>().text = "Well, that’s you! The young apprentice! After being kicked out of traditional schooling, Wilfred found a new master who encouraged with want to experiment and learn on his own.";
        }
        if (this.GetComponent<Text>().text == "Goblins")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            CodexTitle.GetComponent<Text>().text = "Goblins";
            CodexData.GetComponent<Text>().text = "Goblins are a race of small humanoid creatures with green skin who live in tribes across Seidrsund. Goblins are a hunter gatherer society, who survive on raiding settlements around them and passing caravans. Despite their tendency to raid and attack, Goblins are klutzy and rather odd looking. Despite this, they remain dangerous to the unprepared and new wizarding apprentices of the world. Goblins are Nomadic, and tribes rarely stay in the same spot for more than a few months at a time.";
        }

        #endregion
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SpellDesc.GetComponent<Text>().text = "";
        SpellTitle.GetComponent<Text>().text = "";
        SpellIcon.GetComponent<Image>().sprite = null;
        CodexData.GetComponent<Text>().text = "";
        CodexTitle.GetComponent<Text>().text = "";
        CodexIcon.GetComponent<Image>().sprite = null;
        VillageTaskList.SetActive(false);
        ForestTaskList.SetActive(false);
        CastleTaskList.SetActive(false);
        MountainTaskList.SetActive(false);
        MiscTaskList.SetActive(false);
    }
}
