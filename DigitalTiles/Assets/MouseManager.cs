using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static MouseManager instance;
    public List<Tile> currentPath;

    public bool mouseDown;

    public List<RecipeScriptable> possiRecipes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            mouseDown = true;
        }
        else
        {
            mouseDown = false;
            if(currentPath.Count > 0)
            {
                int matchingIndex = FindMatchingRecipe();
                if (matchingIndex != -1)
                {
                    BoardManager.instance.activeRecipes.Add(possiRecipes[matchingIndex]);
                    ChangePathState(Tile.state.locked);
                }
                else
                {
                    ChangePathState(Tile.state.dead);
                }
                

            }

        }
        



    }



    int FindMatchingRecipe()
    {
        foreach(RecipeScriptable r in possiRecipes)
        {
            if (r.ingredients.Count() == currentPath.Count) {
                for (int i = 0; i < currentPath.Count; i++)
                {
                    if (r.ingredients[i] == currentPath[i].value)
                    {
                        if(i == currentPath.Count - 1)
                        {
                            return possiRecipes.IndexOf(r);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            

        }
        return -1;
    }

    void ChangePathState(Tile.state state)
    {
        foreach(Tile t in currentPath)
        {
            t.curState = state;
            t.ChangeColor();
        }

        currentPath = new List<Tile>();
    }
   

}
