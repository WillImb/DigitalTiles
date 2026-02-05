using System.Collections.Generic;
using UnityEngine;

public class SkillNode : MonoBehaviour
{
    bool isAvailable;
    bool isOn;
    public List<SkillNode> nextNodes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (isAvailable)
        {
            foreach(SkillNode s in nextNodes)
            {
                s.TurnedOn();
            }
            isAvailable = false;
        }
    }


    public void TurnedOn()
    {
        isOn = true;
        isAvailable = true;
    }
}
