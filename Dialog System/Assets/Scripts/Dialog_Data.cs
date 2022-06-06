using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Dialog/Data")]
public class Dialog_Data : ScriptableObject
{
    public int NPC_ID;
    [SerializeField] public int defaultStartPoint;
    [SerializeField] public List<Dialog_Segment> data;
}

[System.Serializable]
public class Segment
{
    public bool hasTrigger;
    public int triggerIndex;
    [TextArea(0,5)]
    public string message;
}

