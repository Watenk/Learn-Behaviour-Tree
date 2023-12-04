using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAIManager : MonoBehaviour
{
    public int AiAmount;
    public GameObject AiPrefab;

    private List<TestAI> ais = new List<TestAI>();

    public void Start()
    {
        for (int i = 0; i < AiAmount; i++)
        {
            Instantiate(AiPrefab);
        }
    }
}
