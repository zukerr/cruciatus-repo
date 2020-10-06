using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private ActionBar actionBar = null;
    [SerializeField]
    private EscMenu escMenu = null;
    [SerializeField]
    private LockpickingMechanism lockpicking = null;
    [SerializeField]
    private InventoryUI inventory = null;


    //Keybinds
    [SerializeField]
    private KeyCode basicAttackKey = KeyCode.Mouse0;
    [SerializeField]
    private KeyCode interactKey = KeyCode.Space;
    [SerializeField]
    private KeyCode inventoryKey = KeyCode.I;
    //private KeyCode movementKey = KeyCode.Mouse0;

    private bool escMenuOn = false;
    public static bool soundSettingsOn = false;
    public static bool lockpickingOn = false;

    private void Awake()
    {
        InventoryUI.SetupStatics(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        if(!lockpickingOn)
        {
            if (!escMenuOn)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (!inventory.gameObject.activeSelf)
                        ToggleEscMenu(true);
                    else
                        ToggleInventory();
                }
                if (Input.GetKeyDown(basicAttackKey))
                {
                    //Debug.Log("LMB DOWN");
                    PlayerCharacter.instance.BasicAttackModule.BasicAttackStart();
                }
                if (Input.GetKeyUp(basicAttackKey))
                {
                    //Debug.Log("LMB UP");
                    PlayerCharacter.instance.BasicAttackModule.BasicAttackEnd();
                }
                if (Input.GetKeyDown(interactKey))
                {
                    PlayerInteractableManagement.instance.PlayerInteract();
                }
                if(Input.GetKeyDown(inventoryKey))
                {
                    ToggleInventory();
                }
                HandleKeybinds();
            }
            else
            {
                if (!soundSettingsOn)
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        ToggleEscMenu(false);
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        escMenu.CancelSoundSettingsChanges();
                    }
                }
            }
        }
    }

    public void UseKeybind(int keybindIndex)
    {
        if(keybindIndex >= PlayerCharacter.instance.SpellcastingModule.ActivePlayerSpells.Count)
        {
            return;
        }
        if (Input.GetKeyDown(actionBar.GetKeybind(keybindIndex)))
        {
            //PlayerCharacter.instance.SpellcastingModule.CastActiveSpell(keybindIndex);
            actionBar.ClickActionButton(keybindIndex);
        }
    }

    private void HandleKeybinds()
    {
        for(int i = 0; i < PlayerCharacter.instance.SpellcastingModule.ActivePlayerSpells.Count; i++)
        {
            UseKeybind(i);
        }
    }

    public void ToggleEscMenu(bool value)
    {
        if(value)
        {
            escMenu.gameObject.SetActive(true);
            Time.timeScale = 0f;
            escMenuOn = true;
        }
        else
        {
            escMenu.gameObject.SetActive(false);
            Time.timeScale = 1f;
            escMenuOn = false;
        }
    }

    public void ToggleLockpicking(int oscilatorsCount, ALockable root)
    {
        lockpickingOn = true;
        lockpicking.SetupOscilators(oscilatorsCount, root);
        lockpicking.gameObject.SetActive(true);
    }

    private void ToggleInventory()
    {
        if(inventory.gameObject.activeSelf)
        {
            inventory.gameObject.SetActive(false);
        }
        else
        {
            inventory.gameObject.SetActive(true);
        }
    }
}
