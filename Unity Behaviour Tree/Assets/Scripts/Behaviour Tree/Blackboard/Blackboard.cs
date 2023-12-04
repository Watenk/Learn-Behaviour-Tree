using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard 
{
    private Dictionary<Type, object> data = new Dictionary<Type, object>();

    public void AddType<T>()
    {
        if (!data.ContainsKey(typeof(T)))
        {
            data[typeof(T)] = new BlackboardData<T>();
        }
    }

    public T Get<T>(string _name)
    {
        if (data.TryGetValue(typeof(T), out object dataObject))
        {
            BlackboardData<T> blackboardData = (BlackboardData<T>)dataObject;
            return blackboardData.Get(_name);
        }
        else
        {
            Debug.LogError("Blackboard Doesn't Contain " + typeof(T).Name + " " + _name);
            return default(T);
        }
    }

    public void Set<T>(string _name, T _value)
    {
        if (data.ContainsKey(typeof(T)))
        {
            BlackboardData<T> blackboardData = (BlackboardData<T>)data[typeof(T)];
            blackboardData.Set(_name, _value);
        }
        else
        {
            Debug.LogError("Blackboard Doesn't Contain " + typeof(T).Name + " " + _name);
        }
    }

    public void Add<T>(string _name)
    {
        if (data.ContainsKey(typeof(T)))
        {
            BlackboardData<T> blackboardData = (BlackboardData<T>)data[typeof(T)];
            blackboardData.Add(_name);
        }
        else
        {
            Debug.LogError("Blackboard Doesn't Contain " + typeof(T).Name);
        }
    }

    public void Add<T>(string _name, T _value)
    {
        if (data.ContainsKey(typeof(T)))
        {
            BlackboardData<T> blackboardData = (BlackboardData<T>)data[typeof(T)];
            blackboardData.Add(_name);
            blackboardData.Set(_name, _value);
        }
        else
        {
            Debug.LogError("Blackboard Doesn't Contain " + typeof(T).Name);
        }
    }
}
