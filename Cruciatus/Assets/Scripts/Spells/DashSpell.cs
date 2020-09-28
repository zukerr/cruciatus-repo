using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDashSpell", menuName = "Spells/Dash")]
public class DashSpell : ASpell
{
    [SerializeField]
    private float dashLength = 0f;
    [SerializeField]
    private float dashSpeed = 0f;
    [SerializeField]
    private GameObject particleEffectPrefab = null;

    private bool isDashing = false;

    public override void Cast()
    {
        if(!isDashing)
        {
            PlayerCharacter.instance.StartCoroutine(DashCoroutine());
        }
    }

    public IEnumerator DashCoroutine()
    {
        isDashing = true;
        float trueDashLength = dashLength;

        //EffectsGlobalContainer.instance.InstantiateGreenBubbles(PlayerCharacter.instance.transform);
        GameObject effect = Instantiate(particleEffectPrefab, PlayerCharacter.instance.transform);
        effect.transform.localPosition = new Vector3(0f, -0.3f, 0f);

        Vector3 startPosition = PlayerCharacter.instance.transform.position;
        Vector2 normalizedPlayerToMouse = GlobalVariables.GetPlayerToMouseVector().normalized;
        PlayerCharacter.instance.gameObject.GetComponent<PlayerMovement>().enabled = false;
        Rigidbody2D rbody = PlayerCharacter.instance.gameObject.GetComponent<Rigidbody2D>();

        Collider2D collider = PlayerCharacter.instance.GetComponent<Collider2D>();
        bool dashWontHitWallButOverlapping = false;

        int wallLayerMask = 1 << GlobalVariables.WALL_LAYER_INDEX;
        int invertedWallLayerMask = ~wallLayerMask;
        Vector2 targetPosition = rbody.position + normalizedPlayerToMouse * trueDashLength;
        RaycastHit2D rayHit = Physics2D.Linecast(rbody.position, targetPosition, wallLayerMask);
        //Collider2D[] overlappingColliders = new Collider2D[50];
        if (!rayHit)
        {
            //Debug.DrawLine(rbody.position, targetPosition, Color.yellow, 2f);
            if (collider.IsTouchingLayers(wallLayerMask))
            {
                dashWontHitWallButOverlapping = true;
                /*
                ContactFilter2D tempFilter = new ContactFilter2D();
                tempFilter.SetLayerMask(LayerMask.GetMask(LayerMask.LayerToName(GlobalVariables.WALL_LAYER_INDEX)));
                collider.OverlapCollider(tempFilter, overlappingColliders);
                foreach (Collider2D result in overlappingColliders)
                {
                    if (result != null)
                    {
                        Debug.Log("Overlapping collider: " + result.name);
                    }
                }
                */
            }
        }

        float cTime = 0f;
        while (Vector3.Distance(startPosition, PlayerCharacter.instance.transform.position) < trueDashLength)
        {
            Vector2 newPosition = rbody.position + normalizedPlayerToMouse * Time.fixedDeltaTime * dashSpeed;
            rbody.MovePosition(newPosition);

            if(dashWontHitWallButOverlapping)
            {
                if (collider.IsTouchingLayers(invertedWallLayerMask))
                {
                    //break
                    trueDashLength = -1;
                }
                if (!collider.IsTouchingLayers(wallLayerMask))
                {
                    dashWontHitWallButOverlapping = false;
                }
            }
            else
            {
                int playerTriggersLayerMask = 1 << GlobalVariables.PLAYER_TRIGGERS_LAYER_INDEX;
                if (collider.IsTouchingLayers(~playerTriggersLayerMask))
                {
                    //break
                    trueDashLength = -1;
                }
            }
            
            cTime += Time.fixedDeltaTime;
            yield return null;
        }

        PlayerCharacter.instance.gameObject.GetComponent<PlayerMovement>().enabled = true;
        isDashing = false;
    }
}
