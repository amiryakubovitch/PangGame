using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// contains all the information for the ball physics and calculations
/// </summary>
public class BallModel : MonoBehaviour
{
    public float Size;
    public float SpeedX;
    public float SpeedY;
    public float GravityScale;
    
    //the amount of times the ball wil split
    public int Level;
}
