using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Recipe", order = 1)]
public class RecipeScriptable : ScriptableObject
{
    public float[] ingredients;

    public float value;

}
