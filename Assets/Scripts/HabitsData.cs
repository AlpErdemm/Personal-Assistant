using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class HabitsData
{
    public int currentHabits;
    public List<string> texts;
    public List<bool> isOns;

    public HabitsData(HabitsHandler hHandler)
    {
        currentHabits = hHandler.currentHabits;

        texts = new List<string>();
        isOns = new List<bool>();

        for (int i = 0; i < currentHabits; i++)
        {
            texts[i] = hHandler.habits[i].GetComponentInChildren<TextMeshProUGUI>().text;
            isOns[i] = hHandler.habits[i].GetComponent<Toggle>().isOn;
        }

    }
}
