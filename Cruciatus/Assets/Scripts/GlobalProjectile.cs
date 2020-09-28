using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalProjectile : MonoBehaviour
{
    public static Quaternion GetInitialRotation(Vector2 fromToVector)
    {
        fromToVector.Normalize();
        float normalAngle = GlobalVariables.GetVectorAngle(fromToVector);
        return Quaternion.Euler(new Vector3(0, 0, normalAngle - GlobalVariables.RIGHT_ANGLE));
    }

    public static GameObject InstantiateProjectile(GameObject prefab, Vector2 startPosition, Vector2 targetPosition, float projectileSpeed)
    {
        Vector2 fromToVector = targetPosition - startPosition;
        return InstantiateProjectileGivenFromToVector(prefab, startPosition, fromToVector, projectileSpeed);
    }

    public static GameObject InstantiateProjectileGivenFromToVector(GameObject prefab, Vector2 startPosition, Vector2 fromToVector, float projectileSpeed)
    {
        fromToVector.Normalize();
        Quaternion initialRotation = GetInitialRotation(fromToVector);
        GameObject spawnedBullet = Instantiate(prefab, startPosition, initialRotation);
        spawnedBullet.GetComponent<Rigidbody2D>().AddForce(fromToVector * projectileSpeed);
        return spawnedBullet;
    }
}
