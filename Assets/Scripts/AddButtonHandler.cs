using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtonHandler : MonoBehaviour
{
    [SerializeField] GameObject window;
    public void Add()
    {
        window.SetActive(true);
    }
}
