using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D rbody;

	private bool isWalking = false;
	public bool IsWalking
	{
		get { return isWalking; }
	}

	[SerializeField]
	private float speed = 1.2f;
    [SerializeField]
    private AudioSource walkingSoundEffect = null;
	//Animator anim;

	// Use this for initialization
	void Start () {

		rbody = GetComponent<Rigidbody2D> ();
		//anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
        MovePlayer();
        HandleWalkingSoundEffect();
	}

    public void MovePlayer()
    {
        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Vector2 movementVector = GlobalVariables.GetPlayerToMouseVector();

        movementVector.Normalize();

        if (movementVector != Vector2.zero)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        rbody.MovePosition(rbody.position + movementVector * Time.fixedDeltaTime * speed);
    }

    private void HandleWalkingSoundEffect()
    {
        if(isWalking)
        {
            if (!walkingSoundEffect.isPlaying)
            {
                walkingSoundEffect.Play();
            }
        }
        else
        {
            walkingSoundEffect.Stop();
        }
    }

	
    private void OnDisable()
    {
        /*
        if (anim.gameObject.activeSelf)
        {
            anim.SetBool("iswalking", false);
        }
        */
        walkingSoundEffect.Stop();
    }
    
}
