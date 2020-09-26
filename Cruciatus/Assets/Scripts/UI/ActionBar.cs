using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBar : MonoBehaviour
{
    private const int ACTIONBAR_SIZE = 11;

    [SerializeField]
    private GameObject actionBarGrid = null;
    [SerializeField]
    private PlayerSpellcasting playerSpellcasting = null;

    [Header("Keybinds")]
    [SerializeField]
    private KeyCode slot0 = KeyCode.Alpha1;
    [SerializeField]
    private KeyCode slot1 = KeyCode.Alpha2;
    [SerializeField]
    private KeyCode slot2 = KeyCode.Alpha3;
    [SerializeField]
    private KeyCode slot3 = KeyCode.Alpha4;
    [SerializeField]
    private KeyCode slot4 = KeyCode.Alpha5;
    [SerializeField]
    private KeyCode slot5 = KeyCode.Q;
    [SerializeField]
    private KeyCode slot6 = KeyCode.E;
    [SerializeField]
    private KeyCode slot7 = KeyCode.R;
    [SerializeField]
    private KeyCode slot8 = KeyCode.F;
    [SerializeField]
    private KeyCode slot9 = KeyCode.Z;
    [SerializeField]
    private KeyCode slot10 = KeyCode.X;

    private KeyCode[] slots = new KeyCode[ACTIONBAR_SIZE];

    private void Awake()
    {
        slots[0] = slot0;
        slots[1] = slot1;
        slots[2] = slot2;
        slots[3] = slot3;
        slots[4] = slot4;
        slots[5] = slot5;
        slots[6] = slot6;
        slots[7] = slot7;
        slots[8] = slot8;
        slots[9] = slot9;
        slots[10] = slot10;
    }

    private void Start()
    {
        SetupActionIcons();
    }

    public void SetKeybind(int slotIndex, KeyCode keybind)
    {
        slots[slotIndex] = keybind;
    }

    public KeyCode GetKeybind(int slotIndex)
    {
        return slots[slotIndex];
    }

    public int GetActionbarSize()
    {
        return slots.Length;
    }

    private void SetupActionIcons()
    {
        List<ASpell> playerSpells = playerSpellcasting.ActivePlayerSpells;
        for (int i = 0; i < playerSpells.Count; i++)
        {
            actionBarGrid.transform.GetChild(i).GetComponent<ActionBarSlot>().SetIcon(playerSpells[i].Icon);
            actionBarGrid.transform.GetChild(i).GetComponent<ActionBarSlot>().SetKeybindText(convertKeyCode(slots[i]));
        }
    }

    private string convertKeyCode(KeyCode value)
    {
        string temp = value.ToString();
        if(temp.Length >= 5)
        {
            if (temp.Substring(0, 5).Equals("Alpha"))
            {
                temp = temp.Substring(5);
            }
        }
        return temp;
    }

    public void ClickActionButton(int index)
    {
        actionBarGrid.transform.GetChild(index).GetComponent<ActionBarSlot>().ClickButtonFromOutside();
    }

    public ActionBarSlot GetSlotOfSpell(ASpell spell)
    {
        int index = playerSpellcasting.ActivePlayerSpells.IndexOf(spell);
        return actionBarGrid.transform.GetChild(index).GetComponent<ActionBarSlot>();
    }
}
