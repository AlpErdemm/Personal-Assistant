using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FantomLib;

public class SaveController : MonoBehaviour
{
    [SerializeField] private GameObject habitsHandler;
    [SerializeField] private GameObject tasksHandler;
    [SerializeField] private GameObject TTS;

    /*private void OnApplicationQuit()
    {
        SaveLoad.SaveHabits(habitsHandler.GetComponent<HabitsHandler>());
        SaveLoad.SaveTasks(tasksHandler.GetComponent<TaskHandler>());
    }

    private void OnApplicationPause()
    {
        SaveLoad.SaveHabits(habitsHandler.GetComponent<HabitsHandler>());
        SaveLoad.SaveTasks(tasksHandler.GetComponent<TaskHandler>());
    }*/
}
