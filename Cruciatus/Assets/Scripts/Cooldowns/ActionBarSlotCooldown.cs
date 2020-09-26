using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarSlotCooldown : MonoBehaviour
{
    [SerializeField]
    private Image cooldownImage = null;

    public LiveSpellCooldown RootLiveCooldown { get; set; }

    // Update is called once per frame
    void Update()
    {
        cooldownImage.fillAmount = RootLiveCooldown.CurrentCooldown / RootLiveCooldown.MaxCooldown;
    }
}
