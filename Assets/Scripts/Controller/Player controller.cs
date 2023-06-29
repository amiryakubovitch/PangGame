using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playercontroller controls the logic of a player on screen ( can move the player and create arrows )
/// </summary>
[RequireComponent(typeof(PlayerModel))]
public class Playercontroller : MonoBehaviour , IPlayer
{
    public Action<int> OnHealthChange;
    public Action<int> OnAmmoChange;
    public Action OnDeath;

    PlayerModel model;

    //counts the time until the next recharge
    float ammoRechargeCounter;
    void Start()
    {
        model = GetComponent<PlayerModel>();
        model.CurrentHealth = model.MaxHealth;
        model.CurrentAmmo = model.MaxAmmo;
        OnAmmoChange(model.CurrentAmmo);
        OnHealthChange.Invoke(model.CurrentHealth);
    }

    void Update()
    {
        if(model.invincibilityTimer > 0)
        {
            model.invincibilityTimer-=Time.deltaTime;
            if(model.invincibilityTimer <= 0)
                model.SpriteFlasher.enabled = false;
        }
    }
    

    /// <summary>
    /// Move the player Speed*Time.deltaTime to the left 
    /// </summary>
    public void MoveRight()
    {
        transform.Translate(new Vector3(model.Speed*Time.deltaTime,0,0));
    }

    /// <summary>
    /// Move the player Speed*Time.deltaTime to the right 
    /// </summary>
    public void MoveLeft() 
    {
        transform.Translate(new Vector3(-model.Speed * Time.deltaTime, 0, 0));
    }

    /// <summary>
    /// create a new arrow if the player have enough ammo
    /// </summary>
    public void Shoot()
    {
        if (model.CurrentAmmo > 0)
        {
            model.CurrentAmmo--;
            OnAmmoChange.Invoke(model.CurrentAmmo);

            //create arrow
            GameObject arrow = Instantiate(model.ArrowPrefab);
            arrow.transform.position = model.ArrowHolder.transform.position;
            
            //add an action for when the arrow is destroyed
            ArrowController arrowController = arrow.GetComponent<ArrowController>();
            arrowController.OnArrowDestroy += OnArrowDestroy;
        }
    }

    /// <summary>
    /// called when an arrow is destroyed
    /// </summary>
    public void OnArrowDestroy()
    {
        if (model.CurrentAmmo < model.MaxAmmo)
        {
            model.CurrentAmmo++;
            OnAmmoChange.Invoke(model.CurrentAmmo);
        }
    }

    /// <summary>
    /// handles getting hit logic for the local player
    /// </summary>
    public void getHit()
    {
        if (model.invincibilityTimer > 0|| model.CurrentHealth <= 0)
            return;

        model.CurrentHealth -= 1;
        OnHealthChange.Invoke(model.CurrentHealth);
        if(model.CurrentHealth <= 0)
        {
            //lose
            return;
        }
        model.SpriteFlasher.enabled= true;
        model.invincibilityTimer = model.invincibilityTime;
    }

    /// <summary>
    /// called when a trigger collision enters the player colliders
    /// </summary>
    /// <param name="other">trigger collider</param>
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            getHit();
        }
    }
}
