using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloaterManager : MonoBehaviour
{
    [SerializeField]
    private List<Floater> floaters = new List<Floater>();

    void Start()
    {
        CountFloaters();
        UpdateFloaterCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   void CountFloaters()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Floater>())
            {
                floaters.Add(child.GetComponent<Floater>());
            }
        }
    }
    private void UpdateFloaterCount()
    {
        for (int i = 0; i < floaters.Count; i++)
        {
            floaters[i].floaterCount = floaters.Count;
        }
    }
}
