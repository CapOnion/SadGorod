using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSpawner : MonoBehaviour
{ 
    public int x_range = 4;
    public int y_range = 7;
    [SerializeField]
    public string objectToSpawn;
    public void onClickSpawn()
    {
        float x = Random.Range(-x_range, x_range);
        float y = Random.Range(-y_range, y_range);
        Instantiate(Resources.Load(objectToSpawn), new Vector2(x, y), Quaternion.identity);
    }

}
