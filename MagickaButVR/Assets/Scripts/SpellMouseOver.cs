using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class SpellMouseOver : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{

    public GameObject SpellDesc;
    public GameObject SpellIcon;
    public GameObject SpellTitle;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.GetComponent<Text>().text == "Fireball Q-E-E")
        {
            SpellIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>("Placeholder");
            SpellTitle.GetComponent<Text>().text = "Fireball";
            SpellDesc.GetComponent<Text>().text = "Dis A fire Ball";
        }
        if (this.GetComponent<Text>().text == "GreaseBall Q-R-E")
        {
            SpellDesc.GetComponent<Text>().text = "Geeeease Bitch";
        }
        if (this.GetComponent<Text>().text == "Jump E-Q-Q")
        {
            SpellDesc.GetComponent<Text>().text = "BOING BOING";
        }
        if (this.GetComponent<Text>().text == "Haste E-Q-F")
        {
            SpellDesc.GetComponent<Text>().text = "nyoooooom";
        }
        if (this.GetComponent<Text>().text == "Levitation E-E-Q")
        {
            SpellDesc.GetComponent<Text>().text = "Floaty Boi";
        }
        if (this.GetComponent<Text>().text == "Haste E-Q-F")
        {
            SpellDesc.GetComponent<Text>().text = "nyoooooom";
        }
        if (this.GetComponent<Text>().text == "Telekinesis R-E-Q")
        {
            SpellDesc.GetComponent<Text>().text = "Who needs to lift stuff?";
        }
        if (this.GetComponent<Text>().text == "Light F-R-F")
        {
            SpellDesc.GetComponent<Text>().text = "BRIGHT sparkly bitch";
        }
        if (this.GetComponent<Text>().text == "Identify E-R-F")
        {
            SpellDesc.GetComponent<Text>().text = "I Taste Colors";
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SpellDesc.GetComponent<Text>().text = "";
        SpellTitle.GetComponent<Text>().text = "";
        SpellIcon.GetComponent<Image>().sprite = null;
    }
}
