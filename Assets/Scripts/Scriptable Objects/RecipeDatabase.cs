using UnityEngine;
using System.Collections.Generic; 

[System.Serializable]
public class RecipeData
{
    public ObjectsData ingredient1;
    public ObjectsData ingredient2;
    public GameObject result;

    public bool Matches(ObjectsData a, ObjectsData b)
    {
        return (a == ingredient1 && b == ingredient2) || (a == ingredient2 && b == ingredient1);
    }
}

[CreateAssetMenu(fileName = "RecipeDatabase", menuName = "Alchemy/Recipe Database")]
public class RecipeDatabase : ScriptableObject
{
    public List<RecipeData> recipes = new List<RecipeData>();
}
