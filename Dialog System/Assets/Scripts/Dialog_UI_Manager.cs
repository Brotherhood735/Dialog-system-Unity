using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Dialog_UI_Manager : MonoBehaviour
{
    [Header("Components")]
    public TextMeshProUGUI textLabel;
    public Button goNextLineButton;
    public Transform buttonsArea;
    public Transform choiceButtonPrefab;
    public GameObject DialogUI;
    [Header("Data and Channel")]   
    public Dialog_Data currentData;
    public Dialog_Channel channel;
    public int dialogCount;
    public int currentSection;
    public bool endOfConversation = false;
    public List<Segment> dialogQueue;
    public List<Transform> spawnedButtons;
    private void Start()
    {
        channel.Event += StartConversation;
        goNextLineButton.onClick.AddListener(() => NextLine());
    }
    private void OnDestroy()
    {
        channel.Event -= StartConversation;
        goNextLineButton.onClick.RemoveListener(() => NextLine());
    }
    public void StartConversation(Dialog_Data _data)
    {
        currentData = _data;
        endOfConversation = false;
        ResetUI();
        SetTextAreaVariables(0, currentData.defaultStartPoint, true);
        ToggleUI();
    }
    public void EndConversation()
    {
        ResetUI();
        ToggleUI();
        currentData = null;
        endOfConversation = false;
    }
    void ResetUI()
    {
        SetTextAreaVariables(0, 0);
    }
    public void ToggleUI()
    {
        DialogUI.SetActive(!DialogUI.activeInHierarchy);
    }
    public void NextLine()
    {
        dialogCount++;
        if (dialogCount == dialogQueue.Count)
        {
            //set start point if requested
            if (currentData.data[GetSection(currentSection)].SetStartPoint)
            {
                currentData.defaultStartPoint = currentData.data[GetSection(currentSection)].StartPoint;
            }
            if (endOfConversation)
            {
                EndConversation();
                return;
            }
            goNextLineButton.gameObject.SetActive(false);
            SetUpChoiceButtons();
        }
        if (dialogCount < dialogQueue.Count)
        {
            //trigger the triggers requested
            if (dialogQueue[dialogCount].hasTrigger)
            {
                currentData.data[GetSection(currentSection)].triggers[dialogQueue[dialogCount].triggerIndex].Trigger();
            }
            textLabel.text = dialogQueue[dialogCount].message;
        }
    }
    void SetUpChoiceButtons()
    {
        var _availableChoices = currentData.data[GetSection(currentSection)].next_segments;
        foreach (int choice in _availableChoices)
        {
            var spawnedButton = Instantiate(choiceButtonPrefab, buttonsArea);
            var _manager = spawnedButton.GetComponent<Dialog_Choice_Button_Manager>();
            var _choice_section = currentData.data[GetSection(choice)];
            _manager.choice = choice;
            _manager.label.text = _choice_section.displayMessage;
            spawnedButton.GetComponent<Button>().onClick.AddListener(() => OnChoiceSelectedHandler(
                                                                                                    choice,
                                                                                                    spawnedButton.transform, 
                                                                                                    _choice_section.EndConversation));
            spawnedButtons.Add(spawnedButton);
        }
    }
    void OnChoiceSelectedHandler(int _section, Transform buttonTrans, bool _endOfConversation)
    {
        endOfConversation = _endOfConversation;
        ClearButtons();
        SetTextAreaVariables(0, _section, true);
        ActivateNextButton();
    }
    void ActivateNextButton() => goNextLineButton.gameObject.SetActive(true);
    void DeactivateNextButton() => goNextLineButton.gameObject.SetActive(false);
    void SetTextAreaVariables(int _count, int _section, bool _start=false)
    {
        if (_start) _count = -1; 
        dialogCount = _count;
        currentSection = _section;
        dialogQueue = currentData.data[GetSection(currentSection)].segments;
        NextLine();
    }
    int GetSection(int _sectionNum)
    {
        int i = 0;
        foreach (Dialog_Segment segment in currentData.data)
        {
            if (segment.ID == _sectionNum) return i;
            i++;
        }
        return -1;
    }
    void ClearButtons()
    {
        foreach (var button in spawnedButtons)
        {
            Destroy(button.gameObject);
        }
        spawnedButtons.Clear();
    }
}
