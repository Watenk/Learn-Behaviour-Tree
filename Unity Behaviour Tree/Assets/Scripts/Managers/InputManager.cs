using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public event Action OnW;
    public event Action OnA;
    public event Action OnS;
    public event Action OnD;

    public void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.W) && OnW != null) { OnW(); }
        if (Input.GetKey(KeyCode.A) && OnA != null) { OnA(); }
        if (Input.GetKey(KeyCode.S) && OnS != null) { OnS(); }
        if (Input.GetKey(KeyCode.D) && OnD != null) { OnD(); }
    }
}