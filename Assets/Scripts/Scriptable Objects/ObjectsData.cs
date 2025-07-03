using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class ObjectsData : ScriptableObject
{
    [SerializeField] string prefabName;
    
    public string PrefabName{
        get {
            return prefabName;
        }
    }
}
