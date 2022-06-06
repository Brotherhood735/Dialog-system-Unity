using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Dialog/Trigger")]
public class Dialog_Trigger : ScriptableObject
{
    public Action Event;
    
    public void Trigger()
    {
        Debug.Log("trigger triggered");
        if(Event != null)
        {
            Event?.Invoke();
        }
    }
}
