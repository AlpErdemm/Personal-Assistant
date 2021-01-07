using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeLeftHandler : MonoBehaviour
{
    [SerializeField] GameObject taskObject;
    [SerializeField] GameObject circle;

    private int value;
    private string type;

    public void callUpdate()
    {
            Calculate();
            UpdateText();
            UpdateImportance();
            UpdateColor();
    }
    void Calculate()
    {
        TimeSpan timeLeft = taskObject.GetComponent<Task>().mytask.date - DateTime.Now;

        if ((int)timeLeft.TotalDays > 365)
        {
            type = "y";
            value = ((int)timeLeft.TotalDays)/365;
        }
        else if ((int)timeLeft.TotalDays > 30)
        {
            type = "m";
            value = ((int)timeLeft.TotalDays) / 30;
        }
        else if ((int)timeLeft.TotalDays > 0)
        {
            type = "d";
            value = ((int)timeLeft.TotalDays);
        }
        else if ((int)timeLeft.TotalHours > 0)
        {
            type = "h";
            value = (int)timeLeft.TotalHours;
        }
        else if ((int)timeLeft.TotalMinutes > 0)
        {
            type = "min";
            value = (int)timeLeft.TotalMinutes;
        }
        else
        {
            type = "p";
            value = -1;
        }
    }
    void UpdateText()
    {
        GetComponent<TextMeshProUGUI>().text = value + " " + type;
    }
    void UpdateImportance()
    {
        if(type.Equals("y") || type.Equals("m") || (type.Equals("d") && value > 7))
        {
            taskObject.GetComponent<Task>().mytask.importance = TaskHandler.Importance.VeryLow;
        }
        else if (type.Equals("d") && value > 4)
        {
            taskObject.GetComponent<Task>().mytask.importance = TaskHandler.Importance.Low;
        }
        else if (type.Equals("d") && value > 2)
        {
            taskObject.GetComponent<Task>().mytask.importance = TaskHandler.Importance.Medium;
        }
        else if (type.Equals("d"))
        {
            taskObject.GetComponent<Task>().mytask.importance = TaskHandler.Importance.High;
        }
        else
        {
            taskObject.GetComponent<Task>().mytask.importance = TaskHandler.Importance.VeryHigh;
        }
    }
    void UpdateColor()
    {
        if (taskObject.GetComponent<Task>().mytask.importance == TaskHandler.Importance.VeryLow)
        {
            circle.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
        }
        else if (taskObject.GetComponent<Task>().mytask.importance == TaskHandler.Importance.Low)
        {
            circle.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
        }
        else if (taskObject.GetComponent<Task>().mytask.importance == TaskHandler.Importance.Medium)
        {
            circle.GetComponent<Image>().color = new Color32(255, 167, 0, 255);
        }
        else if (taskObject.GetComponent<Task>().mytask.importance == TaskHandler.Importance.High)
        {
            circle.GetComponent<Image>().color = new Color32(255, 104, 0, 255);
        }
        else if (taskObject.GetComponent<Task>().mytask.importance == TaskHandler.Importance.VeryHigh)
        {
            circle.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
    }
}
