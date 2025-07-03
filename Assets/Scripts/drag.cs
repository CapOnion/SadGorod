using UnityEngine;

public class drag : MonoBehaviour
{
    [SerializeField]
    private ObjectsData objectData;

    [SerializeField]
    private Recepies recepies;

    private Vector2 mousePosition;

    private float offsetX, offsetY;

    public static bool mouseButtonReleased;

    Transform parentAfterDrag;

    private void OnMouseDown()
    {
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;
        transform.SetParent(parentAfterDrag);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        string thisGameobjectName;
        string collisionGameobjectName;
    
        thisGameobjectName = objectData.PrefabName;
        collisionGameobjectName = collision.GetComponent<drag>().objectData.PrefabName;
        
        if (recepies.SpawnObject(thisGameobjectName, collisionGameobjectName)){
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
 
}
