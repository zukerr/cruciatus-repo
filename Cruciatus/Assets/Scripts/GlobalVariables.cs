using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables
{
    public const float RIGHT_ANGLE = 90f;
    public const float MELEE_RANGE = 1f;
    public const string AC_PARAMETER_IS_ATTACKING = "attacking";
    public const int WALL_LAYER_INDEX = 8;
    public const int ENEMY_LAYER_INDEX = 11;
    public const int PLAYER_LAYER_INDEX = 13;

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        mouseWorldPos.z = 0;
        return mouseWorldPos;
    }

    public static Vector3 GetPlayerToMouseVector()
    {
        Vector3 mouseWorldPos = GetMouseWorldPosition();
        Vector3 playerPos = PlayerCharacter.instance.transform.position;

        Vector2 playerToMouse = mouseWorldPos - playerPos;
        return playerToMouse;
    }

    public static float GetVectorAngle(Vector2 vector)
    {
        return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
    }
}
