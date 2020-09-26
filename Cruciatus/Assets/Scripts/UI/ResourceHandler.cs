using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceHandler : MonoBehaviour
{
    [SerializeField]
    protected Image resourceImage = null;
    [SerializeField]
    protected float animationSpeed = 0.5f;
    [SerializeField]
    protected float maxResource = 5f;

    public float ResourceValue { get; protected set; }

    private bool animating = false;
    private bool animBreak = false;

    protected virtual void Start()
    {

    }

    protected float GetNormalizedResourceValue()
    {
        return ResourceValue * (1f / maxResource);
    }

    public virtual void ModifyResource(float value)
    {
        if (value == 0)
        {
            return;
        }
        float oldValue = GetNormalizedResourceValue();
        resourceImage.fillAmount = oldValue;
        ResourceValue += value;
        if (ResourceValue > maxResource)
        {
            ResourceValue = maxResource;
        }
        if (ResourceValue < 0)
        {
            ResourceValue = 0;
        }

        //animate it and show on orb
        if(animating)
        {
            resourceImage.fillAmount = GetNormalizedResourceValue();
            StopAllCoroutines();
            animating = false;
        }
        StartCoroutine(AnimateResourceModificationCoroutine(oldValue));
    }

    private IEnumerator AnimateResourceModificationCoroutine(float oldValue)
    {
        animating = true;
        animBreak = false;
        float newValue = GetNormalizedResourceValue();
        float difference = newValue - oldValue;
        float speedMultiplier = Mathf.Abs(difference * maxResource);
        float currentAnimationSpeed = animationSpeed * speedMultiplier;
        bool moreSpirit = difference > 0;
        if (moreSpirit)
        {
            while ((resourceImage.fillAmount < newValue) && (!animBreak))
            {
                resourceImage.fillAmount += Time.deltaTime * currentAnimationSpeed;
                yield return null;
            }
        }
        else
        {
            while ((resourceImage.fillAmount > newValue) && (!animBreak))
            {
                resourceImage.fillAmount -= Time.deltaTime * currentAnimationSpeed;
                yield return null;
            }
        }
        resourceImage.fillAmount = newValue;
        animBreak = false;
        animating = false;
    }
}
