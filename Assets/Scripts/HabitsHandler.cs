using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HabitsHandler : MonoBehaviour
{
    public int currentHabits = 0;

    public List<GameObject> habits;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject habitPrefab;
    [SerializeField] Vector2 initialHabitPosition;
    [SerializeField] DragController DragController;

    private void Awake()
    {
      /*  Input.backButtonLeavesApp = true;
        HabitsData data = SaveLoad.LoadHabits();

        if(data != null)
        {
            currentHabits = data.currentHabits;
            maxHabits = data.maxHabits;

            for (int i = 0; i < maxHabits; i++)
            {
                habits[i].GetComponentInChildren<TextMeshProUGUI>().text = data.texts[i];
                habits[i].GetComponent<Toggle>().isOn = data.isOns[i];
            }

            for (int i = 0; i < currentHabits; i++)
                habits[i].SetActive(true);
        }       */ 
    }

    public void addHabit(string habitText)
    {

        Vector2 _position = new Vector2(initialHabitPosition.x, initialHabitPosition.y - (130 * currentHabits));

        GameObject _habit = Instantiate(habitPrefab);
        _habit.transform.SetParent(panel.transform);
        _habit.GetComponent<RectTransform>().localPosition = _position;

        _habit.GetComponentInChildren<TextMeshProUGUI>().text = habitText;


        _habit.GetComponent<RectTransform>().localScale = panel.transform.localScale;


        habits.Add(_habit);

        currentHabits++;

        int overflowing = currentHabits - 11;

        if (overflowing > 0)
        {
            DragController.maxY += 130;
        }
    }

    public void RemoveHabit(int ID)
    {
        for (int i = 0; i < currentHabits; i++)
        {
            Debug.Log("Xs?");
            if (habits[i].GetInstanceID().Equals(ID))
            {
                Debug.Log("Xd?");
                if (currentHabits > 0)
                {
                    currentHabits--;
                    rearrengeList(habits[i]);
                    return;
                }

            }
        }
    }
    private void rearrengeList(GameObject go)
    {
        Debug.Log("Ayo!");
        int index = habits.IndexOf(go);

        habits.Remove(go);
        Destroy(go);

        for (int i = index; i < currentHabits; i++)
        {
            Vector3 _position = habits[i].GetComponent<RectTransform>().localPosition;
            _position = new Vector3(_position.x, _position.y + 30, _position.z);
            habits[i].GetComponent<RectTransform>().localPosition = _position;
        }
    }
}
