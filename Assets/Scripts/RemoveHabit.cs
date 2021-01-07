using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveHabit : MonoBehaviour
{
    [SerializeField] GameObject parent;
     public void remove()
    {
        GameObject.Find("Habits").GetComponent<HabitsHandler>().RemoveHabit(parent.GetInstanceID());
    }
}
