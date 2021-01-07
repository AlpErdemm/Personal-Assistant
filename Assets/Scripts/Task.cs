using UnityEngine;
using System;
using TMPro;

public class Task : MonoBehaviour
{

    public TaskHandler.timedTask mytask = new TaskHandler.timedTask();

    public void initializeTask(DateTime date, string taskText, TaskHandler.Importance importance)
    {
        mytask = new TaskHandler.timedTask();
        mytask.date = date;
        mytask.title = taskText;
        mytask.importance = importance;
        GetComponentInChildren<TextMeshProUGUI>().text = taskText;
        GetComponentInChildren<TimeLeftHandler>().callUpdate();
    }
}
