using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This component makes a sprite flash while the componant is active
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class FlashSprite : MonoBehaviour
{
    public float speed;

    SpriteRenderer spriteRenderer;
    int modifier;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        modifier = -1;
    }

    public void Update()
    {
        //calculate the new alpha values
        Color color = spriteRenderer.color;
        color.a +=Time.deltaTime*speed*modifier;
        //set limits and change modifiers
        if(color.a<=0) 
        {
            color.a = 0;
            modifier = 1;
        }
        else if(color.a>=1) 
        {
            color.a = 1;
            modifier = -1;
        }
        spriteRenderer.color=color;
    }

    /// <summary>
    /// return the alpha value to normals before disable
    /// </summary>
    public void OnDisable()
    {
        Color color = spriteRenderer.color;
        color.a = 1;
        spriteRenderer.color = color;
    }
}
