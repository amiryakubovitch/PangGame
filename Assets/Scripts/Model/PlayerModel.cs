using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// hold all the information of a player 
/// </summary>
public class PlayerModel : MonoBehaviour
{
    public int MaxHealth;
    public int MaxAmmo;
    public float Speed;
    public float invincibilityTime;
    public GameObject ArrowPrefab;
    public GameObject ArrowHolder;
    public FlashSprite SpriteFlasher;
    [HideInInspector]
    public int CurrentHealth;
    [HideInInspector]
    public int CurrentAmmo;
    [HideInInspector]
    public float invincibilityTimer;


    public void Start()
    {
        CurrentHealth = MaxHealth;
        CurrentAmmo = MaxAmmo;
        invincibilityTimer = 0;
    }
}
