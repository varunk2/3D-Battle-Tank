﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDirectionControl : MonoBehaviour
{
    public bool useRelativeRotation = true;

    private Quaternion _relativeRotation;
    void Start()
    {
        _relativeRotation = transform.parent.localRotation;
    }

    void Update()
    {
        if (useRelativeRotation) {
            transform.rotation = _relativeRotation;
        }
    }
}