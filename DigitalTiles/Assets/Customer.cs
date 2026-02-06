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
