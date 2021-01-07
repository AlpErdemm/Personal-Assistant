using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class TasksData
{
    public int currentTasks;
    public List<string> titles;
    public List<string> Dates;
    public List<TaskHandler.Importance> imports;

    public TasksData(TaskHandler tHandler)
    {
        currentTasks = tHandler.currentTasks;

        titles = new List<string>();
        Dates = new List<string>();
        imports = new List<TaskHandler.Importance>();

        for (int i = 0; i < currentTasks; i++)
        {
            titles.Add(tHandler.tasks[i].GetComponent<Task>().mytask.title);
            Dates.Add(tHandler.tasks[i].GetComponent<Task>().mytask.date.ToString());
            imports.Add(tHandler.tasks[i].GetComponent<Task>().mytask.importance);

        }
    }
}