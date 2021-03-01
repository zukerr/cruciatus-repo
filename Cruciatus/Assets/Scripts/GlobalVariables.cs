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
    public const int PROJECTILE_LAYER_INDEX = 12;
    public const int PLAYER_TRIGGERS_LAYER_INDEX = 15;
    public const float ETERNAL_COOLDOWN = 9999f;
    public const int EQUIPMENT_SLOTS_COUNT = 10;
    public const int SORTING_LAYER_BEHIND_UI = 99;
    public const int SORTING_LAYER_IN_FRONT_OF_UI = 101;

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

    public static Vector2 GetVectorBetweenPoints(Vector2 from, Vector2 to)
    {
        return to - from;
    }

    public static float GetVectorAngle(Vector2 vector)
    {
        return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
    }

    public static bool IsWallBetweenPositions(Vector2 a, Vector2 b)
    {
        int wallLayerMask = 1 << GlobalVariables.WALL_LAYER_INDEX;
        RaycastHit2D rayHit = Physics2D.Linecast(a, b, wallLayerMask);
        //Debug.DrawLine(a, b, Color.yellow, 1f);
        if (rayHit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
