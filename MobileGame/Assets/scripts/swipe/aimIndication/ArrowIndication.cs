using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndication : Indicator
{
    [SerializeField] private GameObject Arrow;
    
    // Update is called once per frame
    void Update()
    {
        if (Arrow.activeSelf)
        {
            Arrow.
        }
    }

    public override void StartIndication(Vector2 position, float time)
    {
        Arrow.SetActive(true);
    }

    public override void StopIndication(Vector2 position, float time)
    {
        Arrow.SetActive(false);
    }
}
