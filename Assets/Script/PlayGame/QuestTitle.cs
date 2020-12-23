using Assets.Script.Store_Data;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class QuestTitle : MonoBehaviour
{
    public UnityEvent unityEvent;

    public string questTitle;
    public TextMeshProUGUI button_quest_text;

    private void Update()
    {
        button_quest_text.text = questTitle;
    }


    public void Select()
    {
        unityEvent.Invoke();
    }
}
