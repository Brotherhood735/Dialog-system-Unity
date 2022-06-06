using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialog_Frontend_Manager : MonoBehaviour
{
    public string segment_name;
    public TMP_InputField segment_name_input;
    public void CreateSegment()
    {
        var test = ScriptableObject.CreateInstance<Dialog_Segment>();
        Asset_Save_Manager.instance.CreateAsset(test, segment_name);
    }
    public void UpdateSegmentName(string _text)
    {
        segment_name = segment_name_input.text;
    }
}
