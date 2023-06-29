using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// iteface the provides basic player functinallity, provided for modularity to add online player in the future 
/// </summary>
public interface IPlayer
{
    public void MoveRight();

    public void MoveLeft();

    public void Shoot();
}
