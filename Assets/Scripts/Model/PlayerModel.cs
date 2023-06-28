using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public int MaxHealth;
    public int MaxAmmo;
    public float Speed;
    public GameObject ArrowPrefab;
    public GameObject ArrowHolder;
    [HideInInspector]
    public int CurrentHealth;
    [HideInInspector]
    public int CurrentAmmo;

    public void Start()
    {
        CurrentHealth = MaxHealth;
        CurrentAmmo = MaxAmmo;
    }
}