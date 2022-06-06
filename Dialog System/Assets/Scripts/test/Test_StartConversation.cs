using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_StartConversation : MonoBehaviour
{
    public Dialog_Channel channel;

    public Button srtconverNPC;

    public Dialog_Data test_data;
    private void Start()
    {
        srtconverNPC.onClick.AddListener(OnStartConversation);
    }
    private void OnDestroy()
    {
        srtconverNPC.onClick.RemoveListener(OnStartConversation);
    }
    private void OnStartConversation()
    {
        channel.RaiseEvent(test_data);
    }
}
