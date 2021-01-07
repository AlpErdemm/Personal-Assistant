using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddHabitHandler : MonoBehaviour
{
    [SerializeField] GameObject parent;
    [SerializeField] GameObject input;
    [SerializeField] GameObject HabitHandler;
    public void Add()
    {
        HabitHandler.GetComponent<HabitsHandler>().addHabit(input.GetComponent<TMP_InputField>().text);
        closeWindow();
    }

    void closeWindow()
    {
        input.GetComponent<TMP_InputField>().text = "";
        parent.SetActive(false);
    }
}
