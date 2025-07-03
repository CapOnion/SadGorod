using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSpawner : MonoBehaviour
{ 
    public int x_range = 4;
    public int y_range = 7;
    public void onClickSpawn()
    {
       string btnName = EventSystem.current.currentSelectedGameObject.name;
        float x = Random.Range(-x_range, x_range);
        float y = Random.Range(-y_range, y_range);
        if (btnName == "ButtonHoe"){
            Instantiate(Resources.Load("Hoe_object"), new Vector2(x, y), Quaternion.identity);
        }
        else if (btnName == "ButtonDirt"){
            Instantiate(Resources.Load("Dirt_object"), new Vector2(x, y), Quaternion.identity);
        }
        else if (btnName == "ButtonSeeds_blue"){
            Instantiate(Resources.Load("Seeds_Blue_0_object"), new Vector2(x, y), Quaternion.identity);
        }
    }

}
