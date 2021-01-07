using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class TaskHandler : MonoBehaviour
{
    public class timedTask
    {
        public timedTask()
        {
            title = "";
            date = new DateTime();
            importance = Importance.High;
        }
        public string title;
        public DateTime date;
        public Importance importance;
    }

    public enum Importance
    {
        VeryHigh,
        High,
        Medium,
        Low,
        VeryLow        
    }
    
    public int currentTasks = 0;

    public List<GameObject> tasks;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject taskPrefab;
    [SerializeField] Vector2 initialTaskPosition;
    [SerializeField] DragController DragController;

    public void Awake()
    {
        /*if (File.Exists(Application.persistentDataPath + "/tasks.bin"))
        {

            File.Delete(Application.persistentDataPath + "/tasks.bin");

        }

        TasksData data = SaveLoad.LoadTasks();

        if (data != null)
        {
            currentTasks = data.currentTasks;

            for (int i = 0; i < currentTasks; i++)
            {
                tasks[i].GetComponent<Task>().initializeTask(DateTime.Parse(data.Dates[i]), data.titles[i], data.imports[i]);
                tasks[i].GetComponent<Task>().GetComponentInChildren<TextMeshProUGUI>().text = data.titles[i];
            }

            for (int i = 0; i < currentTasks; i++)
                tasks[i].SetActive(true);
        }*/
    }

    public void addTask(string taskText, Importance importance, DateTime date)
    {

        Vector2 _position = new Vector2(initialTaskPosition.x, initialTaskPosition.y - (130 * currentTasks));

        GameObject _task = Instantiate(taskPrefab);
        _task.transform.SetParent(panel.transform);
        _task.GetComponent<RectTransform>().localPosition = _position;

        _task.GetComponent<Task>().initializeTask(date, taskText, importance);
        _task.GetComponentInChildren<TextMeshProUGUI>().text = taskText;

        _task.GetComponent<RectTransform>().localScale = panel.transform.localScale;


        tasks.Add(_task);
        sortTasks();

        currentTasks++;

        int overflowing = currentTasks - 11;

        if(overflowing > 0)
        {
            DragController.maxY += 130;
        }
    }

    private void sortTasks()
    {
        for (int i = 0; i < currentTasks; i++)
        {
            for (int j = 0; j < currentTasks; j++)
            {
                if (tasks[j].GetComponent<Task>().mytask.date > tasks[j + 1].GetComponent<Task>().mytask.date)
                {
                    Task temp = new Task();
                    temp.mytask.date = tasks[j].GetComponent<Task>().mytask.date;
                    temp.mytask.title = tasks[j].GetComponent<Task>().mytask.title;
                    temp.mytask.importance = tasks[j].GetComponent<Task>().mytask.importance;

                    tasks[j].GetComponent<Task>().initializeTask(tasks[j + 1].GetComponent<Task>().mytask.date,
                        tasks[j + 1].GetComponent<Task>().mytask.title,
                        tasks[j + 1].GetComponent<Task>().mytask.importance);

                    tasks[j + 1].GetComponent<Task>().initializeTask(temp.mytask.date,
                        temp.mytask.title,
                        temp.mytask.importance);
                }
            }
        }
        for (int j = 0; j < currentTasks; j++)
        {
            tasks[j].GetComponentInChildren<TextMeshProUGUI>().text = tasks[j].GetComponent<Task>().mytask.title;
        }
    }

    public void RemoveTask(int ID)
    {
        for(int i = 0; i < currentTasks; i++) { 
            if (tasks[i].GetInstanceID().Equals(ID))
            {
                if (currentTasks > 0)
                {
                    currentTasks--;
                    rearrengeList(tasks[i]);
                    return;
                }

            }
        }
    }
    private void rearrengeList(GameObject go)
    {
        int index = tasks.IndexOf(go);

        tasks.Remove(go);        
        Destroy(go);

        for (int i = index; i < currentTasks; i++)
        {
            Vector3 _position = tasks[i].GetComponent<RectTransform>().localPosition;
            _position = new Vector3(_position.x, _position.y + 30, _position.z);
            tasks[i].GetComponent<RectTransform>().localPosition = _position;
        }        
    }
}
