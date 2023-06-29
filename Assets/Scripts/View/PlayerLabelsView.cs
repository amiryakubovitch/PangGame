using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the labels of the player
/// </summary>
public class PlayerLabelsView : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI healthLabel;
    [SerializeField]
    TextMeshProUGUI ammoLabel;

    /// <summary>
    /// sets the local player health label
    /// </summary>
    /// <param name="currentHealth"> amount of health to set</param>
    public void SetHealthLabel(int currentHealth)
    {
        healthLabel.text = "Health:" + currentHealth;
    }

    /// <summary>
    /// sets the local player ammo label
    /// </summary>
    /// <param name="currentAmmo"> amount of ammo to set</param>
    public void SetAmmoLabel(int currentAmmo)
    {
        ammoLabel.text = "Ammo:"+ currentAmmo;
    }
}
