using UnityEngine;
using TMPro;
using System;

public class AddTaskHandler : MonoBehaviour
{
    [SerializeField] GameObject parent;
    [SerializeField] GameObject inputTitle;
    [SerializeField] GameObject inputMinutes;
    [SerializeField] GameObject inputHours;
    [SerializeField] GameObject inputDays;
    [SerializeField] GameObject inputMonths;
    [SerializeField] GameObject inputYears;
    [SerializeField] GameObject TastHandler;

    private void Start()
    {
        inputTitle.GetComponent<TMP_InputField>().text = "";
        inputMinutes.GetComponent<TMP_InputField>().text = DateTime.Now.Minute.ToString();
        inputHours.GetComponent<TMP_InputField>().text = DateTime.Now.Hour.ToString();
        inputDays.GetComponent<TMP_InputField>().text = DateTime.Now.Day.ToString();
        inputMonths.GetComponent<TMP_InputField>().text = DateTime.Now.Month.ToString();
        inputYears.GetComponent<TMP_InputField>().text = DateTime.Now.Year.ToString();
    }
    public void Add()
    {
        DateTime dateTime = new DateTime(
            int.Parse(inputYears.GetComponent<TMP_InputField>().text), 
            int.Parse(inputMonths.GetComponent<TMP_InputField>().text), 
            int.Parse(inputDays.GetComponent<TMP_InputField>().text),
            int.Parse(inputHours.GetComponent<TMP_InputField>().text),
            int.Parse(inputMinutes.GetComponent<TMP_InputField>().text),0);


        TastHandler.GetComponent<TaskHandler>().addTask(inputTitle.GetComponent<TMP_InputField>().text, TaskHandler.Importance.Low, dateTime);

        closeWindow();
    }

    void closeWindow()
    {
        inputTitle.GetComponent<TMP_InputField>().text = "";
        inputMinutes.GetComponent<TMP_InputField>().text = DateTime.Now.Minute.ToString();
        inputHours.GetComponent<TMP_InputField>().text = DateTime.Now.Hour.ToString();
        inputDays.GetComponent<TMP_InputField>().text = DateTime.Now.Day.ToString();
        inputMonths.GetComponent<TMP_InputField>().text = DateTime.Now.Month.ToString();
        inputYears.GetComponent<TMP_InputField>().text = DateTime.Now.Year.ToString();

        parent.SetActive(false);
    }
}
