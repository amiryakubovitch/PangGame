using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerModel))]
public class Playercontroller : MonoBehaviour , IPlayer
{
    PlayerModel model;

    void Start()
    {
        model = GetComponent<PlayerModel>();
        model.CurrentHealth = model.MaxHealth;
        model.CurrentAmmo = model.MaxAmmo;

    }

    public void OnMoveRight()
    {
        transform.Translate(new Vector3(model.Speed*Time.deltaTime,0,0));
    }

    public void OnMoveLeft() 
    {
        transform.Translate(new Vector3(-model.Speed * Time.deltaTime, 0, 0));
    }

    public void OnShoot()
    {
       Instantiate(model.ArrowPrefab,model.ArrowHolder.transform);
    }
}
