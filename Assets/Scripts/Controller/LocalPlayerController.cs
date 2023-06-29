using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls a local player in the game, this handles the player himself using LocalPlayerView's events
/// </summary>
[RequireComponent(typeof(LocalPlayerView))]
public class LocalPlayerController : MonoBehaviour
{
    ///controller of the player on screen
    [SerializeField]
    Playercontroller player;

    LocalPlayerView playerView;

    bool movingLeft;
    bool movingRight;

    public void Awake()
    {
        playerView = GetComponent<LocalPlayerView>();
        movingLeft = false;
        movingRight = false;

        player.OnAmmoChange += OnPlayerAmmoChange;
        player.OnHealthChange += OnPlayerHealthChange;
    }

    public void FixedUpdate()
    {
        //check which movement function should be called ( if any)
        if (player != null) {
            if(movingLeft)
            {
                player.MoveLeft();
            }

            if(movingRight)
            {
                player.MoveRight();
            }
        }
    }

    /// <summary>
    /// Sets the state of moving the player right
    /// </summary>
    /// <param name="movingRight">state to set</param>
    public void SetMovingRight(bool movingRight)
    {
        Debug.Log("moving right:" + movingLeft);
        this.movingRight = movingRight;
    }


    /// <summary>
    /// Sets the state of moving the player left
    /// </summary>
    /// <param name="movingRight">state to set</param>
    public void SetMovingLeft(bool movingLeft)
    {
        this.movingLeft = movingLeft;
    }

    /// <summary>
    /// calls for the player to attack
    /// </summary>
    public void Attack()
    {
        if(player != null)
        {
            player.Shoot();
        }
    }

    /// <summary>
    /// Called when player's health changes, the function changes the ui labels
    /// </summary>
    /// <param name="health">current player's health</param>
    public void OnPlayerHealthChange(int health)
    {
        playerView.SetHealthLabel(health);
    }

    /// <summary>
    /// Called when player's ammo changes, the function changes the ui labels
    /// </summary>
    /// <param name="health">current player's ammo</param>
    public void OnPlayerAmmoChange(int ammo)
    {
        playerView.SetAmmoLabel(ammo);
    }



}
