﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ToggleGroupControl : MonoBehaviour
{
    private ToggleGroup toggleGroup = null;
    private Toggle[] toggles = null;

    [SerializeField]
    private Text result = null;

    // Use this for initialization
    void Start()
    {
        toggleGroup = gameObject.GetComponent<ToggleGroup>();

        toggles = gameObject.GetComponentsInChildren<Toggle>(); // detect all Toggles set as children of this object

        // Register all toggles in the group
        foreach (Toggle toggle in toggles)
        {
            Toggle captured = toggle;   // capture the current toggle in serparate variable, as just capturing the toggle will capture the iterator and all listeners will refer to the last item
            toggle.onValueChanged.AddListener((value) => ToggleStateChanged(captured, value));

            // Assign group to the toggle to enable group logic
            toggle.group = toggleGroup;
        }
    }

    private void ToggleStateChanged(Toggle toggle, bool state)
    {
        // If the toggle was enabled notify the group
        if (state == true)
        {
            result.text = toggle.GetComponentInChildren<Text>().text;
        }
    }

}
