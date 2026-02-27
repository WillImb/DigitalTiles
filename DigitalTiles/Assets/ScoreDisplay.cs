using UnityEngine;
using UnityEngine.UI;
public class ScoreDisplay : MonoBehaviour
{

    public Button leftButton;
    public Button rightButton;

    public GameObject[] panels;
    public int indexer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LeftButtonCLick()
    {
        panels[indexer].SetActive(false);
        indexer--;
        panels[indexer].SetActive(true);

        if(indexer == 0)
        {
            leftButton.interactable = false;
        }
        rightButton.interactable = true;
    }
    
    public void RightButtonCLick()
    {
        panels[indexer].SetActive(false);
        indexer++;
        panels[indexer].SetActive(true);

        if(indexer == panels.Length - 1)
        {
            rightButton.interactable = false;
        }
        leftButton.interactable = true;
    }
}
