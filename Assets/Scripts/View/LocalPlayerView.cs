using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the UI inputs and outputs of the local player
/// </summary>
[RequireComponent(typeof(LocalPlayerController))]
public class LocalPlayerView : MonoBehaviour
{
    [SerializeField]
    AdvancedButton moveLeftBut;
    [SerializeField]
    AdvancedButton moveRightBut;
    [SerializeField]
    AdvancedButton attackBut;
    [SerializeField]
    PlayerLabelsView playerLabels;

    LocalPlayerController playercontroller;


    private void Start()
    {
        playercontroller=GetComponent<LocalPlayerController>();
        moveLeftBut.OnButtonEvent += OnMoveLeft;
        moveRightBut.OnButtonEvent += OnMoveRight;
        attackBut.OnButtonEvent += OnMoveAttack;
    }

    /// <summary>
    /// an event called when move left button is being pressed or released 
    /// </summary>
    /// <param name="clicked">boolean whether the button is held or released</param>
    public void OnMoveLeft(bool clicked)
    {
        playercontroller.SetMovingLeft(clicked);    
    }

    /// <summary>
    /// an event called when move right button is being pressed or released 
    /// </summary>
    /// <param name="clicked">boolean whether the button is held or released</param>
    public void OnMoveRight(bool clicked)
    {
        Debug.Log("clicked right:" + clicked);
        playercontroller.SetMovingRight(clicked);   
    }

    /// <summary>
    /// an event called when attack button is being pressed or released 
    /// </summary>
    /// <param name="clicked">boolean whether the button is held or released</param>
    public void OnMoveAttack(bool clicked)
    {
        if(clicked) 
            playercontroller.Attack();
    }

    /// <summary>
    /// sets the local player health label
    /// </summary>
    /// <param name="currentHealth"> amount of health to set</param>
    public void SetHealthLabel(int currentHealth)
    {
        playerLabels.SetHealthLabel(currentHealth);
    }

    /// <summary>
    /// sets the local player ammo label
    /// </summary>
    /// <param name="currentAmmo"> amount of ammo to set</param>
    public void SetAmmoLabel(int currentAmmo)
    {
        playerLabels.SetAmmoLabel(currentAmmo);
    }

}
