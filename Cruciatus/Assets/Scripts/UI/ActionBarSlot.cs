using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ActionBarSlot : MonoBehaviour
{
    [SerializeField]
    private Image actionIcon = null;
    [SerializeField]
    private TextMeshProUGUI keybindText = null;
    [SerializeField]
    private Button button = null;
    [SerializeField]
    private GameObject cooldownPrefab = null;
    [SerializeField]
    private Image frame = null;

    private GameObject cooldownInstance = null;

    public GameObject InstantiateCooldown(LiveSpellCooldown rootLiveCooldown)
    {
        cooldownInstance = Instantiate(cooldownPrefab, transform);
        cooldownInstance.GetComponent<ActionBarSlotCooldown>().RootLiveCooldown = rootLiveCooldown;
        return cooldownInstance;
    }

    public void DestroyCooldown()
    {
        if(cooldownInstance != null)
        {
            Destroy(cooldownInstance);
        }
    }

    public void SetIcon(Sprite icon)
    {
        actionIcon.sprite = icon;
    }

    public void SetKeybindText(string text)
    {
        keybindText.text = text;
    }

    public void UseThisKeybind()
    {
        PlayerCharacter.instance.SpellcastingModule.CastActiveSpell(transform.GetSiblingIndex());
    }

    public void EnableLMB()
    {
        PlayerCharacter.instance.BasicAttackModule.BasicAttackEnabled = true;
    }

    public void DisableLMB()
    {
        PlayerCharacter.instance.BasicAttackModule.BasicAttackEnabled = false;
    }

    public void ClickButtonFromOutside()
    {
        ExecuteEvents.Execute(button.gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
    }

    public void TurnFrameYellow()
    {
        frame.color = Color.yellow;
    }

    public void TurnFrameBlack()
    {
        frame.color = Color.black;
    }

    public void EnableTooltip()
    {
        if(PlayerCharacter.instance.SpellcastingModule.ActivePlayerSpells.Count <= transform.GetSiblingIndex())
        {
            return;
        }

        string tooltipText = PlayerCharacter.instance.SpellcastingModule.ActivePlayerSpells[transform.GetSiblingIndex()].Description;
        Vector3 topLeft = new Vector3
            (
                transform.position.x,
                transform.position.y,
                transform.position.z
            );
        TooltipController.Instance.DisplayTooltip(topLeft, tooltipText);

        Debug.Log("ActionBarSlot position: " + transform.position);
    }

    public void DisableTooltip()
    {
        TooltipController.Instance.StopDisplayingTooltip();
    }
}
