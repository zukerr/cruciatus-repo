using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecoilBuff", menuName = "DurationEffects/Buffs/Recoil")]
public class RecoilBuff : ADurationEffect
{
    [SerializeField]
    private GameObject procPsPrefab = null;

    public override void OnApplicationAndRefresh()
    {
        base.OnApplicationAndRefresh();
        Instantiate(procPsPrefab, PlayerCharacter.instance.transform);
    }

    public override void StartPersistentEffect()
    {
        base.StartPersistentEffect();
        ASpell disintegrate = PlayerCharacter.instance.SpellcastingModule.ActivePlayerSpells[FindDisintegrationIndex()];
        PlayerCharacter.instance.SpellcastingModule.InstantSpellcastingModule.MakeSpellInstant(disintegrate, true);
    }

    public override void StopPersistentEffect()
    {
        base.StopPersistentEffect();
        ASpell disintegrate = PlayerCharacter.instance.SpellcastingModule.ActivePlayerSpells[FindDisintegrationIndex()];
        PlayerCharacter.instance.SpellcastingModule.InstantSpellcastingModule.MakeSpellInstant(disintegrate, false);
    }
    
    private int FindDisintegrationIndex()
    {
        List<ASpell> playerSpells = PlayerCharacter.instance.SpellcastingModule.ActivePlayerSpells;
        for (int i = 0; i < playerSpells.Count; i++)
        {
            if(playerSpells[i].name.Equals("Disintegrate"))
            {
                return i;
            }
        }
        Debug.LogError("Recoil can't find Disintegrate in ActivePlayerSpells.");
        return 0;
    }
}
