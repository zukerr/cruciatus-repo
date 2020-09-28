using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Flamestrike", menuName = "Spells/Ground Aoe/Flamestrike")]
public class Flamestrike : AGroundAoeSpell
{
    [SerializeField]
    private GameObject flamestrikePrefab = null;

    public override bool CastAvailable()
    {
        if(base.CastAvailable())
        {
            Vector3 playerPos = PlayerCharacter.instance.transform.position;
            Vector3 mouseWorldPos = GlobalVariables.GetMouseWorldPosition();
            if (!GlobalVariables.IsWallBetweenPositions(playerPos, mouseWorldPos))
            {
                return true;
            }
            else
            {
                TextDisplayPlayerInfo.instance.DisplayStringInMsgBoxForTime("Target is not in the line of sight.");
            }
        }
        return false;
    }

    public override void Cast()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        mouseWorldPos.z = 0;
        Vector3 playerPos = PlayerCharacter.instance.transform.position;

        //raycasting
        int layerMask = 1 << GlobalVariables.WALL_LAYER_INDEX;
        if (!Physics2D.Linecast(playerPos, mouseWorldPos, layerMask))
        {
            //Debug.DrawLine(transform.position, mouseWorldPos, Color.yellow, 2f);
            PlayerCharacter.instance.gameObject.GetComponent<PlayerSpellcasting>().PlayOnlyCastingAnimation(delay, this);
            Instantiate(flamestrikePrefab, mouseWorldPos, flamestrikePrefab.transform.rotation);
        }
        else
        {
            Debug.Log("Target not in line of sight!");
        }
    }
}
