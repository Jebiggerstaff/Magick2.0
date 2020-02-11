using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBookScrollEnabler : MonoBehaviour
{
    public UIController UIcontroller;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (UIcontroller.spellsknown > 12)
        {
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 300 + ((UIcontroller.spellsknown-12)*25));
        }
    }
}
