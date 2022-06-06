using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/Segment")]
public class Dialog_Segment : ScriptableObject
{
    [SerializeField] public int ID;
    [SerializeField] public bool SetStartPoint;
    [SerializeField] public int StartPoint;
    [SerializeField] public List<Dialog_Trigger> triggers;
    [SerializeField] public string displayMessage;
    [SerializeField] public bool EndConversation;
    [SerializeField] public List<int> next_segments;
    [SerializeField] public List<Segment> segments;
}
