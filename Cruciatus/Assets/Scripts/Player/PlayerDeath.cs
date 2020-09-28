using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public static PlayerDeath instance;

    [SerializeField]
    private Transform startTransform = null;

    public Vector3 CheckpointPosition { get; set; }
    //private List<GameObject> currentlyDeadMobs;
    //private List<GameObject> checkpointSavedDeadMobs;

    private void Awake()
    {
        instance = this;
        CheckpointPosition = startTransform.position;
        //currentlyDeadMobs = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDeath();
    }

    private void UpdateDeath()
    {
        if(PlayerCharacter.instance.DamagablePlayer.IsDead)
        {
            /*
            PlayerCharacter.instance.gameObject.SetActive(false);

            //move to last checkpoint
            PlayerCharacter.instance.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            PlayerCharacter.instance.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            PlayerCharacter.instance.transform.position = CheckpointPosition;
            PlayerCharacter.instance.DamagablePlayer.ModifyHealth(PlayerCharacter.instance.DamagablePlayer.MaxHealth);
            //DeactivateCheckpointSavedDeadMobs();
            //currentlyDeadMobs = new List<GameObject>(checkpointSavedDeadMobs);

            PlayerCharacter.instance.gameObject.SetActive(true);
            */
            SceneManager.LoadScene(0);
        }
    }

    /*
    private void DeactivateCheckpointSavedDeadMobs()
    {
        foreach(GameObject mob in checkpointSavedDeadMobs)
        {
            mob.SetActive(false);
        }
    }

    public void AddToCurrentlyDeadMobs(GameObject mob)
    {
        currentlyDeadMobs.Add(mob);
    }

    public void ActivateCheckpoint()
    {
        checkpointSavedDeadMobs = new List<GameObject>(currentlyDeadMobs);
    }
    */
}
