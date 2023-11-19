using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeepButtonSelected : MonoBehaviour
{
    private EventSystem eventSystem;
    private GameObject lastSelected = null;
    [SerializeField] private GameObject defaultSelected;

    void Start()
    {
        eventSystem = GetComponent<EventSystem>();
        eventSystem.SetSelectedGameObject(defaultSelected);
    }

    void Update()
    {
        if (eventSystem != null)
        {
            if (eventSystem.currentSelectedGameObject != null)
            {
                lastSelected = eventSystem.currentSelectedGameObject;
            }
            else
            {
                eventSystem.SetSelectedGameObject(lastSelected);
            }
        }
    }
}
