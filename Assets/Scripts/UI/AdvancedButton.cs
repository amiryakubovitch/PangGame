using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// a class for an advanced version of a normal button that provides events for mouse down and mouse up 
/// </summary>
public class AdvancedButton : Button
{

    public Action<bool> OnButtonEvent;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        OnButtonEvent.Invoke(true);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        OnButtonEvent.Invoke(false);
    }
}
