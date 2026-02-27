using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public List<RecipeScriptable> order;

    public int numOfRecipes;

    public int difficuly;

    public float depreciation;
    public float maxHappiness;
    public float happiness;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        happiness = maxHappiness;
        difficuly = GameManager.instance.dayNumber;

        int difficulyCount = difficuly;
        order = new List<RecipeScriptable>();
        while(difficulyCount > 0)
        {
            RecipeScriptable recipe = RoundManager.instance.possibleOrders[Random.Range(0, RoundManager.instance.possibleOrders.Count)];
            difficulyCount -= (int)(recipe.value);
            order.Add(recipe);
        }


    }

    // Update is called once per frame
    void Update()
    {
        happiness -= Time.deltaTime * depreciation;
    }



    public void GiveKudos()
    {
        PlayerPrefs.SetFloat("kudos", PlayerPrefs.GetFloat("kudos", 0) + Mathf.Floor(happiness));
    }
}
