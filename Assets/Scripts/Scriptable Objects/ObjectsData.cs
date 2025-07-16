using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class ObjectsData : ScriptableObject
{
    public GameObject _prefabName;
    
    public GameObject PrefabName{
        get {
            return _prefabName;
        }
    }
}
