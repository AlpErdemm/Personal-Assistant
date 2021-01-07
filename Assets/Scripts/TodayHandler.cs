using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodayHandler : MonoBehaviour
{
    [SerializeField] GameObject TasksHandler;
    [SerializeField] GameObject HabitsHandler;
    [SerializeField] GameObject panel;
    [SerializeField] Vector2 initialTaskPosition;

    List<GameObject> list;


    private TaskHandler taskHandler;
    private HabitsHandler habitsHandler;

    private int todayTasks;
    private int todayHabits;

    private void forceStart()
    {
        taskHandler = TasksHandler.GetComponent<TaskHandler>();
        habitsHandler = HabitsHandler.GetComponent<HabitsHandler>();

        if(list != null)
        {
            foreach (GameObject go in list)
            {
                Destroy(go);
            }
        }       
    }

    public void pullandApplyLists()
    {
        forceStart();
        list = new List<GameObject>();

        todayTasks = taskHandler.currentTasks;
        todayHabits = habitsHandler.currentHabits;

        int count = 0;

        for (int i = 0; i < todayTasks; i++)
        {
          
            Vector2 _position = new Vector2(initialTaskPosition.x, initialTaskPosition.y - (130 * count));
            GameObject _task = Instantiate(taskHandler.tasks[i]);
            _task.transform.SetParent(panel.transform);
            _task.GetComponent<RectTransform>().localPosition = _position;
            _task.GetComponent<RectTransform>().localScale = panel.transform.localScale;
            list.Add(_task);

            count++;
        }

        for (int i = 0; i < todayHabits; i++)
        {
            Vector2 _position = new Vector2(initialTaskPosition.x, initialTaskPosition.y - (130 * count));
            GameObject _habit = Instantiate(habitsHandler.habits[i]);
            _habit.transform.SetParent(panel.transform);
            _habit.GetComponent<RectTransform>().localPosition = _position;
            _habit.GetComponent<RectTransform>().localScale = panel.transform.localScale;
            count++;
            list.Add(_habit);
        }

        int overflowing = count - 11;

        if (overflowing > 0)
        {
            GetComponent<DragController>().maxY += 130 * overflowing;
        }
    }
}
