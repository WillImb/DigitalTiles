using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    public static RoundManager instance;

    public List<GameObject> customers;
    public Customer curCustomer;

    public Transform orderPanel;
    public GameObject displayPrefab;


    public int numOfCustomers;

    float boardScore;
    public float roundScore;
    int boardNumber = 1;
    
    float boardMultSubtract = .5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if(instance  == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(curCustomer == null)
        {
            if (customers.Count > 0)
            {
                SpawnCustomer();
            }
            else
            {
                //end of round
                PlayerPrefs.SetFloat("money", roundScore);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else
        {

        }
    }


    public void StartRound()
    {
        SpawnCustomer();
    }

    public void SpawnCustomer()
    {
        curCustomer = Instantiate(customers[customers.Count - 1]).GetComponent<Customer>();
        DisplayOrder();
    }


    public void SubmitBoard()
    {
        List<RecipeScriptable> activeRec = BoardManager.instance.activeRecipes;
        int submitedRecipes = activeRec.Count;

        
        if (submitedRecipes > 0) {
            
            for (int i = curCustomer.order.Count-1; i >= 0; i--)
            {
                
                if (activeRec.Count == 0)
                {
                    break;
                }
                for (int j = activeRec.Count-1; j >= 0; j--)
                {
                    
                    if (curCustomer.order[i] == activeRec[j])
                    {
                        boardScore += activeRec[j].value;
                        curCustomer.order.Remove(curCustomer.order[i]);
                        activeRec.Remove(activeRec[j]);                        
                        break;

                    }
                    
                }
                
            }
            CalcBoard();

            //clear board, empty acive recipes,
            CreateGrid.instance.RegenerateGrid();
            BoardManager.instance.activeRecipes.Clear();

            ClearDisplay();


            if (curCustomer.order.Count == 0)
            {
                //spawn next customer
                curCustomer.GiveKudos();
                customers.RemoveAt(customers.Count() - 1);
                Destroy(curCustomer.gameObject);
                
                
            }
            else
            {
                DisplayOrder();
            }
        }
    }


    public void DisplayOrder()
    {
        for(int i = 0; i < curCustomer.order.Count; i++) 
        {
            GameObject displayed = Instantiate(displayPrefab, orderPanel.position + new Vector3(.75f + (i%6)*1.25f  - 5, -.75f - Mathf.Floor(i/6)*1.25f + 1.5f), Quaternion.identity,orderPanel);
            displayed.GetComponent<SpriteRenderer>().sprite = curCustomer.order[i].cover;
        }
    }

    public void ClearDisplay()
    {
        Transform[] children = orderPanel.GetComponentsInChildren<Transform>();
        
        for (int i = children.Length-1; i > 0; i--)
        {
            if (children[i].tag == "displayedOrder")
            {
                Destroy(children[i].gameObject);
            }
        }
    }


    public void CalcBoard()
    {
        roundScore += boardScore * Mathf.Pow(boardMultSubtract, boardNumber - 1);
        boardScore = 0;
        boardNumber++;
    }
}
