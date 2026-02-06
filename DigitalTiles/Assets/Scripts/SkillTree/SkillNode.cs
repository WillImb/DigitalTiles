using System.Collections.Generic;
using UnityEngine;

public class SkillNode : MonoBehaviour
{
    public bool isAvailable;
    bool isBought;
    public List<SkillNode> nextNodes;
    public float cost;

    public Color boughtColor;
    public Color avaiableColor;
    public Color offColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeState();
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
            isBought = true;
            ChangeState();
            SkillTreeManager.instance.brainCoins -= cost;
        }
    }


    public void TurnedOn()
    {
        isAvailable = true;
        ChangeState();
    }

    void ChangeState()
    {
        if (isBought)
        {
            GetComponent<SpriteRenderer>().color = boughtColor;
        }
        else if (isAvailable)
        {
            GetComponent<SpriteRenderer>().color = avaiableColor;

        }
        else
        {
            GetComponent<SpriteRenderer>().color = offColor;

        }
    }
}
