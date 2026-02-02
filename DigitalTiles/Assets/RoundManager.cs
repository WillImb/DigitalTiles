using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static RoundManager instance;

    public List<GameObject> customers;
    public Customer curCustomer;
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
    }


    public void SubmitBoard()
    {
        List<RecipeScriptable> activeRec = BoardManager.instance.activeRecipes;
        int submitedRecipes = activeRec.Count;
        

        if (submitedRecipes > 0) {
            for (int i = curCustomer.order.Count; i > 0; i--)
            {
                for (int j = submitedRecipes; j>0; j--)
                {
                    if (curCustomer.order[i] == activeRec[j])
                    {
                        curCustomer.order.Remove(curCustomer.order[i]);
                        activeRec.Remove(activeRec[j]);                        
                        break;

                    }
                }
                
            }
            //clear board, empty acive recipes,
        }
    }
}
