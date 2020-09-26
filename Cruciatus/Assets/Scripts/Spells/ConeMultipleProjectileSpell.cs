using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSingleProjectileSpell", menuName = "Spells/Projectile Spells/Cone Multiple Projectile Spell")]
public class ConeMultipleProjectileSpell : SingleProjectileSpell
{
    [SerializeField]
    protected float coneAngle = 15f;
    [SerializeField]
    protected int bulletOddVolume = 5;

    protected List<float> additionalBulletAngles;

    public override void Cast()
    {
        if(bulletOddVolume % 2 == 0)
        {
            Debug.Log("ConeMultipleProjectileSpell:Cast(): bulletOddVolume is even, whereas it should be odd.");
            return;
        }

        Setup();
        SetupAdditionalBulletsAngles();
        InstantiateProjectile(normalBulletRotation, playerToMouseNormalized);

        for(int i = 0; i < additionalBulletAngles.Count; i++)
        {
            float tempAngle = normalAngle + additionalBulletAngles[i];
            Quaternion tempBulletRotation = Quaternion.Euler(new Vector3(0, 0, tempAngle - GlobalVariables.RIGHT_ANGLE));
            Vector2 tempForceDirection = Quaternion.Euler(0, 0, additionalBulletAngles[i]) * playerToMouseNormalized;
            InstantiateProjectile(tempBulletRotation, tempForceDirection);
        }
    }

    protected void SetupAdditionalBulletsAngles()
    {
        additionalBulletAngles = new List<float>();
        float halfAngle = coneAngle / 2;
        int halfBulletVolume = (bulletOddVolume - 1) / 2;
        float singleAngle = halfAngle / halfBulletVolume;

        float tempAngle = 0f;
        for(int i = 0; i < halfBulletVolume; i++)
        {
            tempAngle += singleAngle;
            additionalBulletAngles.Add(tempAngle);
            additionalBulletAngles.Add(-tempAngle);
        }
        
    }
}
