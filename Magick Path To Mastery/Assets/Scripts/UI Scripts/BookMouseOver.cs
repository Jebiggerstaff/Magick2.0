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

    public GameObject HowToCastSpells;
    public GameObject HowToCastSpellsDesc;
    public GameObject SpellTable;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(this.GetComponent<Text>().text!="")
            DisableTutorialUI();
        #region Spell Page
        if (this.GetComponent<Text>().text == "Fireball Q-E-E")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Fireball");
            SpellTitle.GetComponent<Text>().text = "Fireball";
            SpellDesc.GetComponent<Text>().text = "Sends out a mote of flame, igniting whatever it comes into contact with.";
        }
        if (this.GetComponent<Text>().text == "Tar Pool Q-R-E")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Grease Pool");
            SpellTitle.GetComponent<Text>().text = "Tar Pool";
            SpellDesc.GetComponent<Text>().text = "Creates a pool of tar, slowing any creatures inside it. It may also be ignited to create a flaming barrier.";
        }
        if (this.GetComponent<Text>().text == "Jump E-Q-Q")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Jump");
            SpellTitle.GetComponent<Text>().text = "Jump";
            SpellDesc.GetComponent<Text>().text = "Grants the user to leap to great heights.";
        }
        if (this.GetComponent<Text>().text == "Haste E-Q-F")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Haste");
            SpellTitle.GetComponent<Text>().text = "Haste";
            SpellDesc.GetComponent<Text>().text = "Allows the user to run at super human speeds.";
        }
        if (this.GetComponent<Text>().text == "Levitation E-E-Q")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Levitation");
            SpellTitle.GetComponent<Text>().text = "Levitation";
            SpellDesc.GetComponent<Text>().text = "Suspends an object in the air for a time.";
        }
        if (this.GetComponent<Text>().text == "Telekinesis R-E-Q")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Telekinesis");
            SpellTitle.GetComponent<Text>().text = "Telekinesis";
            SpellDesc.GetComponent<Text>().text = "Allows the user to lift and manipulate an object.";
        }
        if (this.GetComponent<Text>().text == "Light Q-R-F")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Light");
            SpellTitle.GetComponent<Text>().text = "Light";
            SpellDesc.GetComponent<Text>().text = "Conjures a sphere of bright light to illuminate an area.";
        }
        if (this.GetComponent<Text>().text == "Identify E-R-F")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Identify");
            SpellTitle.GetComponent<Text>().text = "Identify";
            SpellDesc.GetComponent<Text>().text = "Reveals objects around the user that can be manipulated by magick.";
        }
        if (this.GetComponent<Text>().text == "Rain Q-F-E")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Rain");
            SpellTitle.GetComponent<Text>().text = "Rain";
            SpellDesc.GetComponent<Text>().text = "Creates a cloud above, bathing the area in rain.";
        }
        if (this.GetComponent<Text>().text == "Polymorph R-E-F")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Polymorph");
            SpellTitle.GetComponent<Text>().text = "Polymorph";
            SpellDesc.GetComponent<Text>().text = "Grow or shrink an object.";
        }
        if (this.GetComponent<Text>().text == "Water Walking R-Q-F")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Water Walk");
            SpellTitle.GetComponent<Text>().text = "Water Walking";
            SpellDesc.GetComponent<Text>().text = "Place a layer of magic between you and the water allowing you to stand on the surface.";
        }
        if (this.GetComponent<Text>().text == "Conjure: Crate F-F-Q")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Conjure");
            SpellTitle.GetComponent<Text>().text = "Conjure: Crate";
            SpellDesc.GetComponent<Text>().text = "Conjure a crate into existance and hold it into existance using magick.";
        }
        if (this.GetComponent<Text>().text == "Conjure: Boulder F-F-E")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Conjure");
            SpellTitle.GetComponent<Text>().text = "Conjure: Boulder";
            SpellDesc.GetComponent<Text>().text = "Conjure a boulder into existance and hold it into existance using magick.";
        }
        if (this.GetComponent<Text>().text == "Teleport: Town F-Q-Q")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Teleport");
            SpellTitle.GetComponent<Text>().text = "Teleport: Town";
            SpellDesc.GetComponent<Text>().text = "Recall a location that you've been before and Teleport there.";
        }
        if (this.GetComponent<Text>().text == "Teleport: Forest F-Q-E")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Teleport");
            SpellTitle.GetComponent<Text>().text = "Teleport: Forest";
            SpellDesc.GetComponent<Text>().text = "Recall a location that you've been before and Teleport there.";
        }
        if (this.GetComponent<Text>().text == "Teleport: Cave F-Q-R")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Teleport");
            SpellTitle.GetComponent<Text>().text = "Teleport: Cave";
            SpellDesc.GetComponent<Text>().text = "Recall a location that you've been before and Teleport there.";
        }
        if (this.GetComponent<Text>().text == "Teleport: Castle F-Q-F")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Teleport");
            SpellTitle.GetComponent<Text>().text = "Teleport: Castle";
            SpellDesc.GetComponent<Text>().text = "Recall a location that you've been before and Teleport there.";
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
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Seidrsund");
            CodexTitle.GetComponent<Text>().text = "Seidrsund";
            CodexData.GetComponent<Text>().text = "Seidrsund, Magic’s Sound, is the name of the land in which all things, living and not, reside. The world is filled with underground roots pulsing with a force that the denizens of the world call Magick. The year, according to the official histories is 1351 SG, Since Growth. This refers to the emergence of the first magick trees discovered.";
        }
        if (this.GetComponent<Text>().text == "Seidrwrot")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Seidrwrot");
            CodexTitle.GetComponent<Text>().text = "Seidrwrot";
            CodexData.GetComponent<Text>().text = "Seidrwrot is the name given to the roots which span throughout the world. Most Seidrwrot are deep within the ground, as their power seeps through the world. The strongest of which pierce the crust of the earth and form into trees which feed magical energy into the world directly. These places are locations of great power, and allow the most powerful of wizards to cast grand and sweeping spells.";
        }
        if (this.GetComponent<Text>().text == "Magick")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Magick");
            CodexTitle.GetComponent<Text>().text = "Magick";
            CodexData.GetComponent<Text>().text = "A mystical force that originates from deep within the earth, and exists in and around all things. It is a force that when harnessed can perform incredible feats. Ancient words from ancestors who could communicate with the very earth itself, when invoked, allow wizards to focus and harness the power of Magick.";
        }
        if (this.GetComponent<Text>().text == "Wizards")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Wizards");
            CodexTitle.GetComponent<Text>().text = "Wizards";
            CodexData.GetComponent<Text>().text = "Wizards, also known as Sorcerers, Magicians, and Casters are those who have trained to harness the magic in the world, and create affects and changes to the world known as Spells. Some are born with old souls, and have a natural aptitude to learning how to wield magick. Their soul on birth was chosen for one reason or another by the spirits of magick that reside in the world.";
        }
        if (this.GetComponent<Text>().text == "The Ancients")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/The Ancients");
            CodexTitle.GetComponent<Text>().text = "The Ancients";
            CodexData.GetComponent<Text>().text = "The ancestors to all people on the continent, they sailed from far, far away. Their language allowed them to communicate with the trees and the grass, the wind and the clouds, the roots and the land. Their ancient language, though only known in pieces, allows users of magick to communicate enough with all around them to craft spells that are a fraction of the power the ancients held in their mouths.";
        }
        if (this.GetComponent<Text>().text == "Yggrskr")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Yggrskr");
            CodexTitle.GetComponent<Text>().text = "Yggrskr";
            CodexData.GetComponent<Text>().text = "Your mentor, the reason you are on this quest. He was not born with an affinity for the Arkane as you were, but managed to learn and master its ways through work and study. He has fallen ill, and no regular medicines have been successful in curing him. Your quest has brought you to this place, where a great tree resides in hopes the powerful magick in the area will offer a solution. Perhaps a local mage has crafted some grand potion? ";
        }
        if (this.GetComponent<Text>().text == "Wilfred Hooplesdorf")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Wilfred Hooplesdorf");
            CodexTitle.GetComponent<Text>().text = "Wilfred Hooplesdorf";
            CodexData.GetComponent<Text>().text = "Well, that’s you! The young apprentice! After being kicked out of traditional schooling, Wilfred found a new master who encouraged with want to experiment and learn on his own.";
        }
        if (this.GetComponent<Text>().text == "Goblins")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Goblins");
            CodexTitle.GetComponent<Text>().text = "Goblins";
            CodexData.GetComponent<Text>().text = "Goblins are a race of small humanoid creatures with green skin who live in tribes across Seidrsund. Goblins are a hunter gatherer society, who survive on raiding settlements around them and passing caravans. Despite their tendency to raid and attack, Goblins are klutzy and rather odd looking. Despite this, they remain dangerous to the unprepared and new wizarding apprentices of the world. Goblins are Nomadic, and tribes rarely stay in the same spot for more than a few months at a time.";
        }
        if (this.GetComponent<Text>().text == "Isle of Bahhl")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Isle of Bahhl");
            CodexTitle.GetComponent<Text>().text = "Isle of Bahhl";
            CodexData.GetComponent<Text>().text = "The island in the Bay of Bahhl is known as The Isle of Bahhl. It is said to hold a secret unknown to simple mortals. It is rumored to be many things: A tunnel, a Portal to another Realm, Buried Treasure. Many have went in search, none have been successful.";
        }
        if (this.GetComponent<Text>().text == "Spellbooks")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Spellbooks");
            CodexTitle.GetComponent<Text>().text = "Spellbooks";
            CodexData.GetComponent<Text>().text = "The spell book is a possession that all students and masters of Magick keeps with them at all times. A magical object in itself, each book is intrinsically linked to its owner, and can be created once more from any blank book, and will contain all former contents before loss or destruction. The magical link between owner and book allows spells cast by the owner to magically be written into the book, including instructions on how to recast them, and their function.";
        }
        if (this.GetComponent<Text>().text == "Master's Cure")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/The Masters Cure");
            CodexTitle.GetComponent<Text>().text = "Master's Cure";
            CodexData.GetComponent<Text>().text = "This glowing bottle of liquid gives off a light purple hue, indicative of healing magic, and by how brightly it glows, extremely powerful healing magic. But something about it gives you the chills: It is cold to the touch. Healing potions are always warm, like freshly brewed tea. You get the feeling that this was created through unclean means. Perhaps, some sort of purification is possible using the power of the tree?";
        }
        if (this.GetComponent<Text>().text == "Mount Soh'ckur")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Mt. Soh'ckur");
            CodexTitle.GetComponent<Text>().text = "Mount Soh'ckur";
            CodexData.GetComponent<Text>().text = "The imposing Mt. Soh’ckur towers above both the town of Whiffleburg. A naturally formed cave has allowed denizens seeking gems and mining work to explore and create a living in the cavernous inside of the mountain. It is said in myth that the mountain was raised long ago on the founding of the town by a great wizard, in order to attract more villagers to settle in the area, though this is unconfirmed. Recently, howling can be heard echoing out of the cave system, and villagers have chosen to avoid the area until a stop is put to it.";
        }
        if (this.GetComponent<Text>().text == "Castle Bahhl")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Bahhls Court");
            CodexTitle.GetComponent<Text>().text = "Castle Bahhl";
            CodexData.GetComponent<Text>().text = "The Bahhl's Court is the name for the castle which houses the administrative center of the County. At his court, the Count entertains guests and sees matters of state and governance. No locals, aside from guardsmen who live at the castle, have ever seen the interior.";
        }
        if (this.GetComponent<Text>().text == "Whiffleburg")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Whiffleburg");
            CodexTitle.GetComponent<Text>().text = "Whiffleburg";
            CodexData.GetComponent<Text>().text = "Whiffleburg, and town in the county of Bahhl, is the town that Wilfred has traveled to in order to find a cure for the illness his master has been afflicted by. Though a small town, it is known for inventing a sport in which players hit balls with sticks, and run around a diamond before being tagged with the ball. It is rumored the Count practices powerful magicks in secret, harnessing the great tree in the center of the town to cast his spells. The potential for powerful potions and miraculous items may be limitless, and Wilfred has to try.";
        }
        if (this.GetComponent<Text>().text == "Count of Bahhl")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/Count of Bahhl");
            CodexTitle.GetComponent<Text>().text = "Count of Bahhl";
            CodexData.GetComponent<Text>().text = "The Count of Bahhl, Baskuit Bahhl has been long rumored to be a powerful wizard, harnessing the ancient magic tree. It is said that he keeps his magic practice a secret due to his tendency to experiment with new and untested spells and potions, which is exactly why Wilfred was drawn to him. Initial messages have fallen on deaf ears, and Wilfred has been unsuccessful in contacting him. Perhaps paying him a visit will pay off?";
        }
        if (this.GetComponent<Text>().text == "The Forest")
        {
            CodexIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Codex/The Forest");
            CodexTitle.GetComponent<Text>().text = "The Forest";
            CodexData.GetComponent<Text>().text = "The small forest adjacent to the town of Whiffleburg is a relatively quiet and peaceful place. A few different paths live between the thick trees, allowing for travel to and from the castle on the cliffs above. Recently, however, a tribe of goblins have entered the forest, setting up camp, and terrorizing the town. With the recent disappearance of the Count and his men, none have been able to drive off the Goblin threat, until the arrival of Wilfred.";
        }


        #endregion
    }

    void DisableTutorialUI()
    {
        HowToCastSpells.SetActive(false);
        HowToCastSpellsDesc.SetActive(false);
        SpellTable.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (this.GetComponent<Text>().text != "")
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
            HowToCastSpells.SetActive(true);
            HowToCastSpellsDesc.SetActive(true);
            SpellTable.SetActive(true);
        }
    }
}
