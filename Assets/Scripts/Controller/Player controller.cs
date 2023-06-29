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
}
