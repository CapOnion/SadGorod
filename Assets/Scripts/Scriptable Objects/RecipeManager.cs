using UnityEngine;
using System.Collections.Generic;

public class RecipeManager : MonoBehaviour
{
    [SerializeField]
    public RecipeDatabase database;

    public GameObject GetResult(ObjectsData a, ObjectsData b)
    {
        foreach (var recipe in database.recipes)
        {
            if (recipe.Matches(a, b))
            {
                return recipe.result;
            }
        }

        return null;
    }
}
