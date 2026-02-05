using System.Collections.Generic;
using UnityEngine;

public class SkillNode : MonoBehaviour
{
    bool isAvailable;
    bool isOn;
    public List<SkillNode> nextNodes;
    public float cost;

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
        if (isAvailable && SkillTreeManager.instance.brainCoins >= cost)
        {
            foreach(SkillNode s in nextNodes)
            {
                s.TurnedOn();
            }
            isAvailable = false;
            SkillTreeManager.instance.brainCoins -= cost;
        }
    }


    public void TurnedOn()
    {
        isOn = true;
        isAvailable = true;
    }
}
