using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsHandler : MonoBehaviour
{
    [SerializeField] GameObject habits;
    [SerializeField] GameObject tasks;
    [SerializeField] GameObject today;
    [SerializeField] GameObject dashboard;

    public void openDashboard()
    {
        dashboard.SetActive(true);
        habits.SetActive(false);
        tasks.SetActive(false);
        today.SetActive(false);
    }
    public void openHabits()
    {
        habits.SetActive(true);
        tasks.SetActive(false);
        today.SetActive(false);
        dashboard.SetActive(false);
    }
    public void openTasks()
    {
        today.SetActive(false);
        habits.SetActive(false);
        tasks.SetActive(true);
        dashboard.SetActive(false);
    }

    public void openToday()
    {
        today.SetActive(true);
        today.GetComponent<TodayHandler>().pullandApplyLists();
        habits.SetActive(false);
        tasks.SetActive(false);
        dashboard.SetActive(false);
    }
}
