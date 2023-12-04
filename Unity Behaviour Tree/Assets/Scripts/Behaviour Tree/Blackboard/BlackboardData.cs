using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Is used to store data in the Blackboard
public class BlackboardData<T>
{
    private Dictionary<string, T> dictionary = new Dictionary<string, T>();

    public void Add(string _name)
    {
        if (!dictionary.ContainsKey(_name))
        {
            dictionary.Add(_name, default(T));
        }
    }

    public T Get(string _name)
    {
        if (dictionary.TryGetValue(_name, out T value))
        {
            return value;
        }
        else
        {
            Debug.LogError("BlackboardData " + typeof(T).Name + " Doesn't Contain " + _name);
            return default(T);
        }
    }

    public void Set(string _name, T _value)
    {
        if (dictionary.ContainsKey(_name))
        {
            dictionary[_name] = _value;
        }
        else
        {
            Debug.LogError("BlackboardData " + typeof(T).Name + " Doesn't Contain " + _name);
        }
    }
}
