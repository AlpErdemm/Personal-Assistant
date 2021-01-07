using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTask : MonoBehaviour
{
    [SerializeField] GameObject parent;
    public void remove()
    {
        GameObject.Find("Tasks").GetComponent<TaskHandler>().RemoveTask(parent.GetInstanceID());
    }
}
