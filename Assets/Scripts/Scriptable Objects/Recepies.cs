using UnityEngine;

[CreateAssetMenu]
public class Recepies : ScriptableObject
{   
    public int x_range = 4;
    public int y_range = 7;

    public bool SpawnObject(string firstObject, string secondObject){
        string resultObject = "";
        
        if (firstObject == "Hoe" && secondObject == "Dirt"){
            resultObject = "Field_object";
        }
        else if (firstObject == "Field" && secondObject == "Seeds_Blue"){
            resultObject = "Grass_object";
        }
        
        if (!string.IsNullOrEmpty(resultObject)){
            float x = Random.Range(-x_range, x_range);
            float y = Random.Range(-y_range, y_range);

            Instantiate(Resources.Load(resultObject), new Vector2(x, y), Quaternion.identity);
            return true;
        }
        else {
            return false;
        }
        
    }
}
