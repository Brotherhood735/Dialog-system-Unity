using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Dialog/Channel")]
public class Dialog_Channel : ScriptableObject
{
    public Action<Dialog_Data> Event;

    public void RaiseEvent(Dialog_Data _Data)
    {
        if (Event != null)
        {
            Event?.Invoke(_Data);
        }
    }
}
