using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerApplicableDurationEffects : AApplicableDurationEffects
{
    [SerializeField]
    private GameObject durationEffectUiPrefab = null;
    [SerializeField]
    private GameObject effectsGrid = null;

    protected override void AddNewLiveEffect(List<LiveCooldownDurationEffect> liveList, ADurationEffect durationEffect)
    {
        base.AddNewLiveEffect(liveList, durationEffect);
        GameObject nEffect = Instantiate(durationEffectUiPrefab, effectsGrid.transform);
        nEffect.GetComponent<UiDurationEffectNode>().RootLiveEffect = GetDurationEffectFromLiveList(liveList, durationEffect);
        nEffect.GetComponent<UiDurationEffectNode>().SetEffectImageSprite(durationEffect.Icon);
    }

    protected override void RemoveLiveEffect(List<LiveCooldownDurationEffect> liveList, LiveCooldownDurationEffect effect)
    {
        base.RemoveLiveEffect(liveList, effect);
        GameObject uiNode = FindUiEffectNode(effect);
        if(uiNode != null)
        {
            Destroy(uiNode);
        }
    }

    protected override void AddStackToLiveEffect(LiveCooldownDurationEffect effect)
    {
        base.AddStackToLiveEffect(effect);
        GameObject uiNode = FindUiEffectNode(effect);
        if (uiNode != null)
        {
            uiNode.GetComponent<UiDurationEffectNode>().SetStacksText(effect.CurrentStacks.ToString());
        }
    }

    protected override void RemoveStackFromLiveEffect(LiveCooldownDurationEffect effect)
    {
        base.RemoveStackFromLiveEffect(effect);
        GameObject uiNode = FindUiEffectNode(effect);
        if (uiNode != null)
        {
            if(effect.CurrentStacks > 1)
            {
                uiNode.GetComponent<UiDurationEffectNode>().SetStacksText(effect.CurrentStacks.ToString());
            }
            else
            {
                uiNode.GetComponent<UiDurationEffectNode>().SetStacksText("");
            }
        }
    }

    private GameObject FindUiEffectNode(LiveCooldownDurationEffect effect)
    {
        for (int i = 0; i < effectsGrid.transform.childCount; i++)
        {
            LiveCooldownDurationEffect rootEffect = effectsGrid.transform.GetChild(i).GetComponent<UiDurationEffectNode>().RootLiveEffect;
            if (rootEffect.Equals(effect))
            {
                return effectsGrid.transform.GetChild(i).gameObject;
            }
        }
        Debug.LogError("ERROR: Didn't find Ui effect node.");
        return null;
    }
}
