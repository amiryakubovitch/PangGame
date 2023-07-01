using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// represent the layout of a level
/// </summary>
[CreateAssetMenu(fileName ="New Layout",menuName ="Level/Layout")]
public class LevelLayout : ScriptableObject
{
    [Serializable]
    public struct ballInLayout
    {
        public BallScriptable Ball;
        public Vector2 Position;
    }
    public List<ballInLayout> ballScriptables;
}
